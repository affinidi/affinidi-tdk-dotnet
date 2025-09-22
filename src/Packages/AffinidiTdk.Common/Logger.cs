namespace AffinidiTdk.Common
{
    public static class Logger
    {
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"[INFO] {message}");
            Console.ResetColor();
        }

        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[SUCCESS] {message}");
            Console.ResetColor();
        }

        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] {message}");
            Console.ResetColor();
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            Console.ResetColor();
        }

        public static void Exception(Exception ex, bool showStackTrace = false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[EXCEPTION] [{ex.GetType().Name}] {ex.Message}");
            Console.ResetColor();

            if (showStackTrace && !string.IsNullOrWhiteSpace(ex.StackTrace))
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
