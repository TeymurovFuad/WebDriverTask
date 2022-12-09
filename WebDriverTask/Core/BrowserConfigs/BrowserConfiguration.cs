using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Core.BrowserConfigs
{
    public class Browser
    {
        [JsonProperty("Browsers")]
        public Dictionary<string, BrowserConfig> Browsers { get; set; }
    }

    public class BrowserConfig
    {
        [JsonProperty("options")]
        public Dictionary<string, Option> Options { get; set; }

        [JsonProperty("settings")]
        public Dictionary<string, Setting> Settings { get; set; }
    }

    public class Option
    {
        [JsonProperty("options")]
        public Dictionary<string, string> Options { get; set; }
    }

    public class Setting
    {
        [JsonProperty("settins")]
        public Dictionary<string, string> Settings { get; set; }
    }
}
