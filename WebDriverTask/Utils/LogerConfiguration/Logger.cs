using System.Text.RegularExpressions;

namespace WebDriverTask.Utils.LogerConfiguration
{
    public abstract class Logger : ILogger
    {
        protected readonly object lockObj = new object();

        public string CurrentDirectory { get; private set; }
        public string LogFileName { get; private set; }
        public  string LogFolderPath { get; private set; }
        public string LogFilePath { get; private set; }

        protected Logger(string fileName)
        {
            lockObj = new object();
            CurrentDirectory = Environment.CurrentDirectory;
            LogFileName = ValidateFileName(fileName);
            LogFolderPath = Path.Combine(CurrentDirectory, "Log");
            LogFilePath = Path.Combine(CurrentDirectory, "Log", LogFileName);
        }

        private string ValidateFileName(string fileName)
        {
            string pattern = @"^[a-z0-9]{1,}\.txt";
            Match match = Regex.Match(input: fileName, pattern: pattern, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                throw new ArgumentException($"Given filename ({fileName}) does not match pattern ({pattern})");
            }
            return fileName;
        }

        protected void Log(string message)
        {
            lock (lockObj)
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(LogFolderPath);
                using (StreamWriter streamWriter = File.AppendText(LogFilePath))
                {
                    streamWriter.Write("> Log entry: ");
                    streamWriter.WriteLine($"{DateTime.Now}");
                    streamWriter.WriteLine($"\t:{message}");
                }
            }
        }
    }
}
