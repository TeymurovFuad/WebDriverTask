using System.Text.RegularExpressions;

namespace Core.Utils.LogerConfiguration
{
    public class Logger : BaseLogger
    {
        private readonly object lockObj = new object();
        private string _logFileName { get; set; } = "Log.txt";

        public override string CurrentDirectory { get; protected set; }
        public override string LogFolderPath { get; protected set; }
        public override string LogFilePath { get; protected set; }
        public override string LogFileName
        {
            get => _logFileName;
            protected set => _logFileName = ValidateFileName(value);
        }

        protected Logger()
        {
            CurrentDirectory = Environment.CurrentDirectory;
            LogFolderPath = Path.Combine(CurrentDirectory, "Log");
            CreateDirectory(LogFolderPath);
        }

        private string ValidateFileName(string fileName)
        {
            string pattern = @"^[a-z0-9]{1,}\.txt";
            Match match = Regex.Match(input: fileName, pattern: pattern, RegexOptions.IgnoreCase);
            if (string.IsNullOrEmpty(fileName) || !match.Success)
            {
                throw new ArgumentException($"Given filename ({fileName}) does not match pattern ({pattern})");
            }
            return fileName;
        }

        public override async Task Log(string message)
        {
            await Task.Run(() =>
            {
                lock (lockObj)
                {
                    LogFilePath = Path.Combine(LogFolderPath, LogFileName);
                    using (StreamWriter streamWriter = File.AppendText(LogFilePath))
                    {
                        streamWriter.Write($"> Log entry: {DateTime.Now}");
                        streamWriter.WriteLine($" : LogType => {message}\n");
                    }
                }
            });
        }

        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
