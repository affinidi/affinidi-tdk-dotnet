using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace IntegrationTests.Helpers
{
    public static class Utils
    {
        public static string? ExtractRevocationStatusId(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            Uri uri;
            try
            {
                uri = new Uri(url);
            }
            catch (UriFormatException)
            {
                return null;
            }

            var path = uri.AbsolutePath;
            if (string.IsNullOrWhiteSpace(path))
                return null;

            var segments = path.Trim('/').Split('/');
            return segments.Length > 0 ? segments[^1] : null;
        }

        public static string GenerateRandomString()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            var result = new char[12];

            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[1];
                for (int i = 0; i < result.Length; i++)
                {
                    int index;
                    do
                    {
                        rng.GetBytes(buffer);
                        index = buffer[0] % chars.Length;
                    } while (index < 0 || index >= chars.Length);

                    result[i] = chars[index];
                }
            }

            return new string(result);
        }
    }
}
