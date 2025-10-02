using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DotNetEnv;

namespace IntegrationTests
{
    internal static class EnvLoader
    {
        [ModuleInitializer]
        internal static void Init()
        {
            Env.TraversePath().Load();

            var required = new[]
            {
                "PROJECT_ID",
                "TOKEN_ID",
                "PRIVATE_KEY",
                "IOTA_CONFIGURATION",
                "IOTA_PRESENTATION_DEFINITION",
                "IOTA_PRESENTATION_SUBMISSION",
                "VERIFIABLE_PRESENTATION",
                "VERIFIABLE_CREDENTIAL",
                "UNSIGNED_CREDENTIAL_PARAMS",
                "CREDENTIAL_ISSUANCE_DATA",
                "CREDENTIAL_ISSUANCE_CONFIGURATION"
            };

            var missing = required
                .Where(key => string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(key)))
                .ToList();

            if (missing.Count > 0)
            {
                Console.WriteLine("[FATAL] Missing required environment variables:");
                foreach (var key in missing)
                {
                    Console.WriteLine($"  - {key}");
                }

                Environment.Exit(1); // Fails immediately
            }

            Console.WriteLine("[ENV] Loaded and validated.");
        }
    }
}
