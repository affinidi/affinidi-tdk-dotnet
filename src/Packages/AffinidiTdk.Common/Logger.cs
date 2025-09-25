using System;

namespace AffinidiTdk.Common
{
    public enum LogLevel
    {
        None = 0,
        Error = 1,
        Warn = 2,
        Info = 3,
        Debug = 4
    }

    public static class Logger
    {
        public static LogLevel MinimumLevel { get; set; } = LogLevel.None;

        static Logger()
        {
            var raw = System.Environment.GetEnvironmentVariable("AFFINIDI_TDK_LOG_LEVEL");

            if (!string.IsNullOrWhiteSpace(raw) &&
                Enum.TryParse<LogLevel>(raw, ignoreCase: true, out var level))
            {
                MinimumLevel = level;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[TDK] [WARN] Invalid log level: '{raw}'. Falling back to 'None'.");
                Console.ResetColor();
            }
        }

        public static void Debug(string message)
        {
            if (MinimumLevel >= LogLevel.Debug)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"[TDK] [DEBUG] {message}");
                Console.ResetColor();
            }
        }

        public static void Info(string message)
        {
            if (MinimumLevel >= LogLevel.Info)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[TDK] [INFO] {message}");
                Console.ResetColor();
            }
        }

        public static void Warn(string message)
        {
            if (MinimumLevel >= LogLevel.Warn)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[TDK] [WARN] {message}");
                Console.ResetColor();
            }
        }

        public static void Error(string message)
        {
            if (MinimumLevel >= LogLevel.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[TDK] [ERROR] {message}");
                Console.ResetColor();
            }
        }

        public static void Exception(Exception ex, bool showStackTrace = true)
        {
            if (MinimumLevel >= LogLevel.Error)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"[TDK] [EXCEPTION] [{ex.GetType().Name}] {ex.Message}");
                Console.ResetColor();

                if (showStackTrace && !string.IsNullOrWhiteSpace(ex.StackTrace))
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
