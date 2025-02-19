using shopping_app_auth.Services.Interfaces;

namespace shopping_app_auth.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly string _logFilePath;


        public LoggerService() {}

        public void LogInfo(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"WARNING: {message}");
        }

        public void LogError(string message, Exception ex)
        {
            Console.WriteLine($"ERROR: {message} - Exception: {ex.Message}");
        }
    }
}