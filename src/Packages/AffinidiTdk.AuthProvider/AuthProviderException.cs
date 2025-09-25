using System;

namespace AffinidiTdk.AuthProvider
{
    public class AuthProviderException : Exception
    {
        public AuthProviderException(string message, Exception? innerException = null)
            : base(message, innerException)
        {
        }
    }
}
