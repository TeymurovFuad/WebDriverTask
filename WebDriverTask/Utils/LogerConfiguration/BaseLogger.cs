using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebDriverTask.Utils.LogerConfiguration
{
    public abstract class BaseLogger : ILogger
    {
        public abstract string CurrentDirectory { get; protected set; }
        public abstract string LogFileName { get; protected set; }
        public abstract string LogFolderPath { get; protected set; }
        public abstract string LogFilePath { get; protected set; }

        public abstract void Log(string message);
    }
}
