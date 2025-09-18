using Jose;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AffinidiTdk.AuthProvider
{
    public class ValidateTokenResult
    {
        public bool IsValid { get; init; }
        public bool IsExpired { get; init; }
    }

    public class Jwt
    {
        private readonly HttpClient _httpClient = new();

        public ValidateTokenResult ValidateToken(string token, string publicKey)
        {
            try
            {
                using var ecdsa = ECDsa.Create();
                ecdsa.ImportFromPem(publicKey);

                var payload = JWT.Decode<Dictionary<string, object>>(token, ecdsa, JwsAlgorithm.ES256);

                var isExpired = payload.TryGetValue("exp", out var exp) &&
                                DateTimeOffset.UtcNow >= DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));

                return new ValidateTokenResult { IsValid = true, IsExpired = isExpired };
            }
            catch (IntegrityException)
            {
                return new ValidateTokenResult { IsValid = false, IsExpired = false };
            }
            catch
            {
                return new ValidateTokenResult { IsValid = false, IsExpired = false };
            }
        }

        public async Task<string> FetchPublicKeyAsync(string apiGatewayUrl)
        {
            var response = await _httpClient.GetStringAsync($"{apiGatewayUrl}/iam/.well-known/jwks.json");

            var jwks = JsonSerializer.Deserialize<JwksResponse>(response);

            var jwk = jwks?.Keys?.Count > 0 ? jwks.Keys[0] : throw new InvalidOperationException("No JWKs found");

            return JwkToPem(jwk);
        }

        public string JwkToPem(JwkKey jwk)
        {
            var ecParams = new ECParameters
            {
                Curve = ECCurve.NamedCurves.nistP256,
                Q =
                {
                    X = Base64UrlDecode(jwk.X),
                    Y = Base64UrlDecode(jwk.Y)
                }
            };

            using var ecdsa = ECDsa.Create(ecParams);
            var derBytes = ecdsa.ExportSubjectPublicKeyInfo();
            return ExportToPem("PUBLIC KEY", derBytes);
        }

        private static string ExportToPem(string label, byte[] der)
        {
            var base64 = Convert.ToBase64String(der);
            var sb = new StringBuilder();
            sb.AppendLine($"-----BEGIN {label}-----");

            for (int i = 0; i < base64.Length; i += 64)
                sb.AppendLine(base64.Substring(i, Math.Min(64, base64.Length - i)));

            sb.AppendLine($"-----END {label}-----");
            return sb.ToString();
        }

        private static byte[] Base64UrlDecode(string input)
        {
            input = input.Replace('-', '+').Replace('_', '/');
            return Convert.FromBase64String(input.PadRight(input.Length + (4 - input.Length % 4) % 4, '='));
        }
    }

    public class JwksResponse
    {
        [JsonPropertyName("keys")]
        public List<JwkKey> Keys { get; set; } = [];
    }

    public class JwkKey
    {
        [JsonPropertyName("crv")]
        public string Crv { get; set; }

        [JsonPropertyName("x")]
        public string X { get; set; }

        [JsonPropertyName("y")]
        public string Y { get; set; }
    }
}
