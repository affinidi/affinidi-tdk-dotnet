using System;
using System.Threading.Tasks;
using AffinidiTdk.Common;

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
                Logger.Error($"Exception in: {context}");
                Logger.Exception(ex, showStackTrace: true);
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
                Logger.Error($"Exception in: {context}");
                Logger.Exception(ex, showStackTrace: true);
                throw new AuthProviderException($"[{context}] {ex.Message}", ex);
            }
        }
    }
}
