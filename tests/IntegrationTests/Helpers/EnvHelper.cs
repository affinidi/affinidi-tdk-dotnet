using System;
using System.Collections.Generic;
using System.Linq;
using DotNetEnv;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Helpers
{
    public static class EnvHelper
    {
        private static readonly HashSet<string> _missingVariables = new();

        static EnvHelper()
        {
            // Load from .env by traversing path upward
            Env.TraversePath().Load();

            // Force evaluation to catch missing required variables at startup
            _ = TokenId;
            _ = PrivateKey;
            _ = ProjectId;
            _ = VerifiableCredential;
            _ = VerifiablePresentation;
            _ = CredentialIssuanceData;
            _ = CredentialIssuanceConfiguration;
            _ = UnsignedCredentialParams;
            _ = IotaConfiguration;
            _ = IotaPresentationSubmission;
            _ = IotaPresentationDefinition;

            if (_missingVariables.Any())
            {
                throw new InvalidOperationException(
                    $".env is missing required variables: {string.Join(", ", _missingVariables.OrderBy(v => v))}"
                );
            }
        }

        private static string GetEnvVar(string name, bool required = false, string defaultValue = "")
        {
            var value = Environment.GetEnvironmentVariable(name);
            if (!string.IsNullOrEmpty(value))
                return value;

            if (required)
            {
                _missingVariables.Add(name);
                return string.Empty;
            }

            return defaultValue;
        }

        private static JObject GetJsonObject(string name)
        {
            var raw = GetEnvVar(name, required: true);
            try
            {
                return JObject.Parse(raw);
            }
            catch (Exception ex)
            {
                throw new FormatException($"Invalid JSON in environment variable '{name}': {ex.Message}", ex);
            }
        }

        // Required string vars
        public static string TokenId => GetEnvVar("TOKEN_ID", required: true);
        public static string PrivateKey => GetEnvVar("PRIVATE_KEY", required: true);
        public static string ProjectId => GetEnvVar("PROJECT_ID", required: true);

        // To be converted to DTO class
        public static string UnsignedCredentialParams => GetEnvVar("UNSIGNED_CREDENTIAL_PARAMS", required: true);
        public static string IotaConfiguration => GetEnvVar("IOTA_CONFIGURATION", required: true);
        public static string VerifiablePresentation => GetEnvVar("VERIFIABLE_PRESENTATION", required: true);
        public static string IotaPresentationSubmission => GetEnvVar("IOTA_PRESENTATION_SUBMISSION", required: true);
        public static string IotaPresentationDefinition => GetEnvVar("IOTA_PRESENTATION_DEFINITION", required: true);
        public static string CredentialIssuanceConfiguration => GetEnvVar("CREDENTIAL_ISSUANCE_CONFIGURATION", required: true);

        public static string CredentialIssuanceData => GetEnvVar("CREDENTIAL_ISSUANCE_DATA", required: true);

        // Optional string vars
        public static string KeyId => GetEnvVar("KEY_ID");
        public static string Passphrase => GetEnvVar("PASSPHRASE");

        // Required JSON env vars
        public static JObject VerifiableCredential => GetJsonObject("VERIFIABLE_CREDENTIAL");
    }
}
