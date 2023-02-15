using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Utils.LogConfig
{
    public class LoggerConfig
    {
        private static string _logFileName = "log";

        private static long _nowInMilliseconds { get; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        private static string CurrentDirectory { get; set; }
        private static string LogFolderPath { get; set; }
        public static string LogFileName
        {
            get => _logFileName;
            protected set => _logFileName = ValidateFileName(value);
        }

        protected LoggerConfig()
        {
            ConfigureLogger();
        }

        public static ILogger ConfigureLogger()
        {
            CreateDirectory();
            string logFilePath = $@"{LogFolderPath}\{LogFileName}_{_nowInMilliseconds}.txt";
            string logOutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(path: logFilePath, outputTemplate: logOutputTemplate)
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();
            return Log.Logger;
        }

        private static string ValidateFileName(string fileName)
        {
            string pattern = @"^[a-z0-9]{1,}\.txt";
            Match match = Regex.Match(input: fileName, pattern: pattern, RegexOptions.IgnoreCase);
            if (string.IsNullOrEmpty(fileName) || !match.Success)
            {
                throw new ArgumentException($"Given filename ({fileName}) does not match pattern ({pattern})");
            }
            return fileName;
        }

        private static void CreateDirectory()
        {
            string month = String.Format("{0:MMMM}", DateTime.Now);
            string day = DateTime.Now.Day.ToString();
            CurrentDirectory = Environment.CurrentDirectory;
            LogFolderPath = Path.Combine(CurrentDirectory, "Log", month, day);
            if (!Directory.Exists(LogFolderPath))
                Directory.CreateDirectory(LogFolderPath);
        }
    }
}
