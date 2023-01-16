using System.IO;

namespace WebDriverTask.Utils.LogerConfiguration
{
    public abstract class Logger : ILogger
    {
        protected readonly object lockObj = new object();

        public string CurrentDirectory { get; set; }
        public string LogFileName { get; set; }
        public string LogFilePath { get; set; }

        public Logger()
        {
            lockObj = new object();
            CurrentDirectory = Environment.CurrentDirectory;
            LogFileName = "Log.txt";
            LogFilePath = Path.Combine(CurrentDirectory, "Log", LogFileName);
        }

        public void Log(string message)
        {
            lock (lockObj)
            {
                using (StreamWriter streamWriter = new StreamWriter(LogFilePath, true))
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
