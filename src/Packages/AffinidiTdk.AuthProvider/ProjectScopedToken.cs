using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace AffinidiTdk.AuthProvider
{
    public class ProjectScopedToken
    {
        public string SignPayload(string tokenId, string audience, string privateKey, string keyId, string? passphrase)
        {
            var issuedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            using var rsa = RSA.Create();

            if (!string.IsNullOrEmpty(passphrase))
                rsa.ImportFromEncryptedPem(privateKey, passphrase);
            else
                rsa.ImportFromPem(privateKey);

            var securityKey = new RsaSecurityKey(rsa) { KeyId = keyId };
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256);

            var payload = new JwtPayload
            {
                { "iss", tokenId },
                { "sub", tokenId },
                { "aud", audience },
                { "jti", Guid.NewGuid().ToString() },
                { "exp", issuedAt + 300 },
                { "iat", issuedAt }
            };

            var token = new JwtSecurityToken(new JwtHeader(credentials), payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string?> GetUserAccessToken(string tokenId, string audience, string privateKey, string? passphrase, string keyId)
        {
            var jwt = SignPayload(tokenId, audience, privateKey, keyId, passphrase);

            var formData = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials",
                ["scope"] = "openid",
                ["client_assertion_type"] = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer",
                ["client_assertion"] = jwt,
                ["client_id"] = tokenId
            };

            using var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.PostAsync(audience, new FormUrlEncodedContent(formData));
                response.EnsureSuccessStatusCode();

                using var content = await response.Content.ReadAsStreamAsync();
                using var json = await JsonDocument.ParseAsync(content);

                return json.RootElement.GetProperty("access_token").GetString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get user access token: {ex.Message}");
                return null;
            }
        }

        public async Task<string?> FetchProjectScopedToken(string apiGatewayUrl, string projectId, string tokenId, string audience, string privateKey, string keyId, string? passphrase)
        {
            var userAccessToken = await GetUserAccessToken(tokenId, audience, privateKey, passphrase, keyId);
            if (userAccessToken == null)
                return null;

            using var httpClient = new HttpClient();

            var requestUrl = $"{apiGatewayUrl}/iam/v1/sts/create-project-scoped-token";
            var payloadJson = JsonSerializer.Serialize(new { projectId });

            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl)
            {
                Content = new StringContent(payloadJson, Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", userAccessToken);

            try
            {
                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                using var content = await response.Content.ReadAsStreamAsync();
                using var json = await JsonDocument.ParseAsync(content);

                return json.RootElement.GetProperty("accessToken").GetString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to fetch project scoped token: {ex.Message}");
                return null;
            }
        }
    }
}
