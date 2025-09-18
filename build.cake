//////////////////////////////////////////////////////////////////////
// PREAMBLE
//////////////////////////////////////////////////////////////////////

#addin nuget:?package=Newtonsoft.Json&version=13.0.4

#tool nuget:?package=Versionize&version=2.3.1



using Newtonsoft.Json;
using Newtonsoft.Json.Linq;




//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////




Task("Generate-Versionize-Config")
    .Does(() =>
{

    
    
    var srcDir = Directory("./src");
    var changelogSections = new[] {
        new { type = "feat", section = "✨ Features", hidden = false },
        new { type = "fix", section = "🐛 Bug Fixes", hidden = false },
        new { type = "perf", section = "🚀 Performance", hidden = false }
    };

    var projects = new List<object>();

    

    var projectFiles = GetFiles("./src/**/*.csproj");

    foreach (var projectFile in projectFiles)
    {
        var projectDir = projectFile.GetDirectory();
        var name = System.IO.Path.GetFileNameWithoutExtension(projectFile.FullPath);
        var path = projectDir.FullPath.Replace("\\", "/");
        Information($"Adding {name} at {path}");


        projects.Add(new {
            name = name,
            path = path,
            tagTemplate = "{name}-v{version}",
            changelog = new {
                header = $"{name} Changelog",
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
    .Does(() =>
{
    Information("Cleaning previous build artifacts...");
    DeleteDirectories(GetDirectories("./affected*"), new DeleteDirectorySettings {
        Recursive = true,
        Force = true
    });
    try
    {
        DotNetClean("./");
    }
    catch (Exception ex)
    {
        Warning($"Dotnet clean failed: {ex.Message}");
    }

    DeleteFiles(GetFiles("./nupkgs/*.nupkg"));
});


Task("Generate-Solution")
    .IsDependentOn("Clean")
    .Does(() =>
{
    Information("Generating solution file...");
    StartProcess("dotnet", "new sln --name AffinidiTdk --force");

    var projects = GetFiles("**/*.csproj");
    foreach (var project in projects)
    {
        StartProcess("dotnet", $"sln AffinidiTdk.sln add \"{project.FullPath}\"");
    }
});

Task("Lint")
    .IsDependentOn("Generate-Solution")
    .Does(() =>
{
    Information("Running dotnet format...");
    StartProcess("dotnet", "format AffinidiTdk.sln --exclude src/Clients/");
});


Task("Build")
    .IsDependentOn("Lint")
    .Does(() =>
{
    Information("Building all projects...");
    DotNetBuild("AffinidiTdk.sln");
});

Task("Pack")
    .IsDependentOn("Build")
    .Does(() =>
{
    Information("Packing all projects...");
    DotNetPack("AffinidiTdk.sln", new DotNetPackSettings {
        OutputDirectory = "./nupkgs"
    });
});

Task("IntegrationTest")
    .Does(() =>
{
    DotNetTest("AffinidiTdk.sln");
});

Task("Release")
    .IsDependentOn("Generate-Versionize-Config")
    .Does(() =>
{

    var jsonText = System.IO.File.ReadAllText(".versionize");
    var json = JObject.Parse(jsonText);
    var projects = json["projects"];

    foreach (var project in projects)
    {
        var name = project["name"].ToString();
        Information($"🚀 Releasing {name}");
        StartProcess("dotnet", $"versionize --proj-name \"{name}\"");
    }
});

Task("Default")
    .IsDependentOn("Pack");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
