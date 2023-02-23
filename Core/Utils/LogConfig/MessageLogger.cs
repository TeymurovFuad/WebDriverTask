using ILogger = Serilog.ILogger;

namespace Core.Utils.LogConfig
{
    public class MessageLogger: LoggerConfig
    {
        private static ILogger _logger;

        public static ILogger GetLogger()
        {
            _logger ??= ConfigureLogger();
            return _logger;
        }
    }
}
