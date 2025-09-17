using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Jose;

namespace AffinidiTdk.AuthProvider
{
    public interface ISignPayload
    {
        string TokenId { get; set; }
        string Audience { get; set; }
        string PrivateKey { get; set; }
        string Passphrase { get; set; }
        string KeyId { get; set; }
    }

    public class IValidateToken
    {
        public bool IsValid { get; set; }
        public bool IsExpired { get; set; }
    }

    public class Jwt
    {
        private readonly HttpClient _httpClient;

        public Jwt()
        {
            _httpClient = new HttpClient();
        }

        public IValidateToken ValidateToken(string token, string publicKey)
        {
            try
            {
                // Parse the PEM public key
                using var ecdsa = ECDsa.Create();
                ecdsa.ImportFromPem(publicKey);

                // jose-jwt expects the raw key object
                var payload = JWT.Decode<IDictionary<string, object>>(
                    token,
                    ecdsa,
                    JwsAlgorithm.ES256
                );

                bool isExpired = false;

                if (payload.TryGetValue("exp", out var expValue))
                {
                    long expUnix = Convert.ToInt64(expValue);
                    DateTimeOffset expTime = DateTimeOffset.FromUnixTimeSeconds(expUnix);
                    isExpired = DateTimeOffset.UtcNow >= expTime;
                }

                return new IValidateToken { IsValid = true, IsExpired = isExpired };
            }
            catch (IntegrityException)
            {
                // Signature is invalid
                return new IValidateToken
                {
                    IsValid = false,
                    IsExpired = false
                };
            }
            catch (Exception)
            {
                // Any other failure (malformed token, parse error)
                return new IValidateToken
                {
                    IsValid = false,
                    IsExpired = false
                };
            }
        }

        public async Task<string> FetchPublicKey(string apiGatewayUrl)
        {
            var response = await _httpClient.GetStringAsync($"{apiGatewayUrl}/iam/.well-known/jwks.json");
            // TODO: refactor using JsonSerializer.Deserialize faster, core
            //       instead of JsonSerializer.Deserialize<JsonElement>(jwkJson)
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
            // dynamic data = JsonSerializer.Deserialize<JsonElement>(response);

            var jwk = data.keys[0];

            string publicKeyPem = JwkToPem(jwk);

            return publicKeyPem;
        }

        public string JwkToPem(dynamic jwk)
        {
            string crv = jwk.crv;
            string x = jwk.x;
            string y = jwk.y;

            // Decode base64url (note: not base64, this is url-safe)
            byte[] xBytes = Base64UrlDecode(x);
            byte[] yBytes = Base64UrlDecode(y);

            // Create EC parameters
            ECParameters ecParams = new ECParameters
            {
                Curve = ECCurve.NamedCurves.nistP256,
                Q =
                {
                    X = xBytes,
                    Y = yBytes
                }
            };

            using var ecdsa = ECDsa.Create(ecParams);
            byte[] derBytes = ecdsa.ExportSubjectPublicKeyInfo(); // X.509 SPKI

            return ExportToPem("PUBLIC KEY", derBytes);
        }

        // TODO: Do I need BEGIN, END?
        private string ExportToPem(string label, byte[] der)
        {
            string base64 = Convert.ToBase64String(der);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-----BEGIN {label}-----");
            for (int i = 0; i < base64.Length; i += 64)
            {
                sb.AppendLine(base64.Substring(i, Math.Min(64, base64.Length - i)));
            }
            sb.AppendLine($"-----END {label}-----");
            return sb.ToString();
        }

        private byte[] Base64UrlDecode(string base64Url)
        {
            string padded = base64Url.Replace('-', '+').Replace('_', '/');
            switch (padded.Length % 4)
            {
                case 2: padded += "=="; break;
                case 3: padded += "="; break;
            }
            return Convert.FromBase64String(padded);
        }
    }
}
