using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Utils.LogerConfiguration
{
    public interface ILogger
    {
        string CurrentDirectory { get; set; }
        string LogFileName { get; set; }
        string LogFilePath { get; set; }
        void Log(string message);
    }
}
