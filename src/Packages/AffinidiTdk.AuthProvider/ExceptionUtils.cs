using System;
using System.Threading.Tasks;

namespace AffinidiTdk.AuthProvider
{
    public static class ExceptionUtils
    {
        public static async Task<T> WrapAsync<T>(Func<Task<T>> operation, string context)
        {
            try
            {
                return await operation();
            }
            catch (Exception ex)
            {
                throw new AuthProviderException($"[{context}] {ex.Message}", ex);
            }
        }

        public static T Wrap<T>(Func<T> operation, string context)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                throw new AuthProviderException($"[{context}] {ex.Message}", ex);
            }
        }
    }
}
