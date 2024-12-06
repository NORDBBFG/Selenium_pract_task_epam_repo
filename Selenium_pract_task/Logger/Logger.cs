using Microsoft.Extensions.Configuration;
using Serilog;

namespace Selenium_pract_task.Logger
{
    public static class Logger
    {
        private static ILogger _logger;
        private static readonly object LockObject = new object();

        public static void InitializeLogger()
        {
            if (_logger != null) return;

            lock (LockObject)
            {
                if (_logger == null)
                {
                    var configPath = Path.Combine(Directory.GetCurrentDirectory(), "Logger", "LoggerConfig.json");
                    var configuration = new ConfigurationBuilder()
                        .AddJsonFile(configPath, optional: true, reloadOnChange: true)
                        .Build();

                    var logsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "logs");
                    Directory.CreateDirectory(logsFolderPath);

                    _logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .WriteTo.File(
                            path: Path.Combine(logsFolderPath, "test-log-.txt"),
                            rollingInterval: RollingInterval.Day,
                            outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                        )
                        .CreateLogger();

                    _logger.Information("Logger initialized.");
                }
            }
        }

        public static ILogger GetLogger()
        {
            if (_logger == null)
            {
                InitializeLogger();
            }
            return _logger;
        }
    }
}
