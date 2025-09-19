using System;

namespace AffinidiTdk.AuthProvider
{
    public class AuthProviderException : Exception
    {
        public AuthProviderException(string message)
            : base($"[AuthProvider Error] {message}") { }
    }
}
