using System;
using DotNetEnv;

namespace AffinidiTdk.Common
{
    public static class EnvironmentUtils
    {
        private static readonly string DEFAULT_REGION = "ap-southeast-1";

        private static readonly Dictionary<string, string> EnvToApiGwUrl = new()
        {
            { Environment.LOCAL, "https://apse1.dev.api.affinidi.io" },
            { Environment.DEVELOPMENT, "https://apse1.dev.api.affinidi.io" },
            { Environment.PRODUCTION, "https://apse1.api.affinidi.io" }
        };

        private static readonly Dictionary<string, string> EnvToElementsAuthTokenUrl = new()
        {
            { Environment.LOCAL, "https://apse1.dev.auth.developer.affinidi.io/auth/oauth2/token" },
            { Environment.DEVELOPMENT, "https://apse1.dev.auth.developer.affinidi.io/auth/oauth2/token" },
            { Environment.PRODUCTION, "https://apse1.auth.developer.affinidi.io/auth/oauth2/token" }
        };

        private static readonly Dictionary<string, string> EnvToIotUrl = new()
        {
            { Environment.LOCAL, "a3sq1vuw0cw9an-ats.iot.ap-southeast-1.amazonaws.com" },
            { Environment.DEVELOPMENT, "a3sq1vuw0cw9an-ats.iot.ap-southeast-1.amazonaws.com" },
            { Environment.PRODUCTION, "a13pfgsvt8xhx-ats.iot.ap-southeast-1.amazonaws.com" }
        };


        // Fetches the current environment based from environment variables
        public static string FetchEnvironment()
        {
            Env.TraversePath().Load();

            string? backendEnv = System.Environment.GetEnvironmentVariable("AFFINIDI_TDK_ENVIRONMENT");

            if (string.IsNullOrEmpty(backendEnv))
            {
                return Environment.PRODUCTION; // Default to Production
            }

            // Make the check case-insensitive
            backendEnv = backendEnv.ToLower();

            if (Environment.IsValid(backendEnv))
            {
                return backendEnv;
            }

            // Default to production if an invalid environment is passed
            return Environment.PRODUCTION;
        }

        public static string FetchApiGwUrl(string? env = null)
        {
            env ??= FetchEnvironment();
            return EnvToApiGwUrl[env];
        }

        public static string FetchElementsAuthTokenUrl(string? env = null)
        {
            env ??= FetchEnvironment();
            return EnvToElementsAuthTokenUrl[env];
        }

        public static string FetchRegion()
        {
            return DEFAULT_REGION;
        }

        public static string FetchIotUrl(string? env = null)
        {
            env ??= FetchEnvironment();
            return EnvToIotUrl[env];
        }
    }
}
