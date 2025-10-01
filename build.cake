//////////////////////////////////////////////////////////////////////
// PREAMBLE
//////////////////////////////////////////////////////////////////////

#addin nuget: ? package = Newtonsoft.Json & version = 13.0 .4
#tool nuget: ? package = Versionize & version = 2.3 .1

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var projectName = Argument("projectName", "");
var configuration = Argument("configuration", "Release");
//////////////////////////////////////////////////////////////////////
// ENVS
//////////////////////////////////////////////////////////////////////

var isCI = EnvironmentVariable("CI") != null;
var nugetApiKey = EnvironmentVariable("NUGET_API_KEY") ?? "";
var outputDir = "./nupkgs";
var solutionFile = "AffinidiTdk.sln";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Restore-DotNet-Tools")
  .Does(() => {
    StartProcess("dotnet", "tool restore");
  });

Task("Generate-Versionize-Config")
  .Does(() => {
    var srcDir = Directory("./src");
    var changelogSections = new [] {
      new {
        type = "feat", section = "✨ Features", hidden = false
      },
      new {
        type = "fix", section = "🐛 Bug Fixes", hidden = false
      },
      new {
        type = "perf", section = "🚀 Performance", hidden = false
      }
    };

    var projects = new List < object > ();
    var projectFiles = GetFiles("./src/**/*.csproj");
    var rootDir = DirectoryPath.FromString("./").MakeAbsolute(Context.Environment).FullPath;

    foreach(var projectFile in projectFiles) {
      var name = System.IO.Path.GetFileNameWithoutExtension(projectFile.FullPath);

      // Get the directory containing the project file
      var projectDir = projectFile.GetDirectory().FullPath.Replace("\\", "/");

      // Strip the root directory prefix
      var relativeDir = projectDir.StartsWith(rootDir) ?
        projectDir.Substring(rootDir.Length).TrimStart('/') :
        projectDir;

      // Prepend "./" to make it a valid relative path
      var path = $ "{relativeDir}";

      Information($"Adding {name} at {path}");

      projects.Add(new {
        name = name,
          path = path,
          tagTemplate = "{name}-v{version}",
          changelog = new {
            header = $ "{name} Changelog",
              sections = changelogSections
          }
      });
    }

    var config = new {
      skipDirty = true,
        silent = false,
        projects = projects
    };

    var json = JsonConvert.SerializeObject(config, Formatting.Indented);
    System.IO.File.WriteAllText(".versionize", json);
  });

Task("Clean")
  .Does(() => {
    if (FileExists(solutionFile)) {
      return;
    }
    Information("Cleaning previous build artifacts...");
    DeleteDirectories(GetDirectories("./affected*"), new DeleteDirectorySettings {
      Recursive = true,
        Force = true
    });

    try {
      DotNetClean("./");
    } catch (Exception ex) {
      Warning($"Dotnet clean failed: {ex.Message}");
    }

    DeleteFiles(GetFiles($"{outputDir}/*.nupkg"));
  });

Task("Generate-Solution")
  .IsDependentOn("Clean")
  .Does(() => {

    if (FileExists(solutionFile)) {
      return;
    }

    Information("Generating solution file...");
    StartProcess("dotnet", "new sln --name AffinidiTdk --force");

    var projects = GetFiles("**/*.csproj");
    foreach(var project in projects) {
      StartProcess("dotnet", $ "sln {solutionFile} add \"{project.FullPath}\"");
    }
  });

Task("Lint")
  .IsDependentOn("Generate-Solution")
  .Does(() => {
    Information("Running dotnet format...");
    StartProcess("dotnet", $ "format {solutionFile} --verify-no-changes --exclude src/Clients/");
  });

Task("Format")
  .Does(() => {
    Information("Running dotnet format...");
    StartProcess("dotnet", $ "format {solutionFile} --exclude src/Clients/");
  });

Task("Build")
  .IsDependentOn("Lint")
  .Does(() => {
    Information("Building all projects...");
    DotNetBuild(solutionFile);
  });

Task("Pack")
  .IsDependentOn("Generate-Solution")
  .Does(() => {
    var packSettings = new DotNetPackSettings {
      Configuration = configuration,
        OutputDirectory = outputDir,
        IncludeSymbols = true,
        SymbolPackageFormat = "snupkg"
    };
    if (projectName == "") {
      Information("Packing all projects...");
      DotNetPack(solutionFile, packSettings);
      return;
    }

    Information($"Packing {projectName} project");

    var projectPath = GetFiles($"./src/**/{projectName}.csproj").FirstOrDefault();

    DotNetPack(projectPath.FullPath, packSettings);

  });

Task("Publish")
  .IsDependentOn("Pack")
  .Does(() => {
    var package = GetFiles($"{outputDir}/{projectName}.*.nupkg").FirstOrDefault();

    if (package != null) {
      Information($"Pushing {package.FullPath} to NuGet...");
      DotNetNuGetPush(package.FullPath, new DotNetNuGetPushSettings {
        Source = "https://api.nuget.org/v3/index.json",
          ApiKey = nugetApiKey
      });
    } else {
      throw new Exception($"❌ {projectName} pkg not found");
    }
  });

Task("IntegrationTest")
  .Does(() => {
    DotNetTest(solutionFile);
  });

Task("Release")
  .IsDependentOn("Restore-DotNet-Tools")
  .IsDependentOn("Generate-Versionize-Config")
  .Does(() => {
    var jsonText = System.IO.File.ReadAllText(".versionize");
    var json = JObject.Parse(jsonText);
    var projects = json["projects"];
    var dryRunFlag = isCI ? "" : "--dry-run";

    foreach(var project in projects) {
      var name = project["name"].ToString();
      var skipChangelog = name.Contains("Client") ? "--skip-changelog" : "";

      Information($"🚀 Releasing {name} {(isCI ? "
        " : "(dry run mode)
        ")}");
      var settings = new ProcessSettings {
        Arguments = $ "tool run versionize --proj-name \"{name}\" {dryRunFlag} --ignore-insignificant-commits --commit-suffix=\"{name}\" {skipChangelog}",
          RedirectStandardError = false,
          RedirectStandardOutput = false
      };

      var process = StartAndReturnProcess("dotnet", settings);
      process.WaitForExit();

      if (process.GetExitCode() != 0) {
        throw new Exception($"❌ Versionize failed for project {name}");
      }
    }
  });

Task("Default")
  .IsDependentOn("Build")
  .IsDependentOn("Pack")
  .IsDependentOn("Lint");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
