using System.Text.Json.Serialization;

namespace Tests.APITests.Models
{
    public class CompanyDTO: IDTO
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("catchPhrase")]
        public string? CatchPhrase { get; set; }

        [JsonPropertyName("bs")]
        public string? Bs { get; set; }
    }
}
