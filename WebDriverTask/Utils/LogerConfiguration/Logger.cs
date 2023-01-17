using OpenQA.Selenium.DevTools;
using System.IO;

namespace WebDriverTask.Utils.LogerConfiguration
{
    public abstract class Logger : ILogger
    {
        protected readonly object lockObj = new object();

        public string CurrentDirectory { get; protected set; }
        public string LogFileName { get; protected set; }
        public string LogFolderPath { get; protected set; }
        public string LogFilePath { get; private set; }

        public Logger()
        {
            lockObj = new object();
            CurrentDirectory = Environment.CurrentDirectory;
            LogFileName = "Log.txt";
            LogFolderPath = Path.Combine(CurrentDirectory, "Log");
            LogFilePath = Path.Combine(CurrentDirectory, "Log", LogFileName);
        }

        public virtual void Log(string message)
        {
            lock (lockObj)
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(LogFolderPath);
                using (StreamWriter streamWriter = new StreamWriter(LogFilePath))
                {
                    streamWriter.Write("\nLog entry: ");
                    streamWriter.WriteLine($"{DateTime.Now}");
                    streamWriter.WriteLine($"   :{message}");
                    streamWriter.WriteLine("---------------------------------------------");
                }
            }
        }
    }
}
