namespace Common.Helpers
{
    public class Environment
    {
        public static readonly string LOCAL = "local";
        public static readonly string DEVELOPMENT = "dev";
        public static readonly string PRODUCTION = "prod";

        public static bool IsValid(string environment)
        {
            return environment == LOCAL || environment == DEVELOPMENT || environment == PRODUCTION;
        }
    }
}
