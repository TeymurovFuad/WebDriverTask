using Newtonsoft.Json;

namespace Core.Browser
{
    public class BrowserDto
    {
        [JsonProperty("Browsers")]
        public Dictionary<string, BrowserConfig> Browsers { get; set; }
    }

    public class BrowserConfig
    {
        [JsonProperty("options")]
        public List<Option> Options { get; set; }

        [JsonProperty("settings")]
        public List<Setting> Settings { get; set; }
    }

    public class Option
    {
        public Dictionary<string, string> Argument { get; set; }
    }

    public class Setting
    {
        public Dictionary<string, string> Preference { get; set; }
    }
}
