using System.Text.Json.Serialization;

namespace Tests.APITests.Models
{
    public class GeoDTO: IDTO
    {
        [JsonPropertyName("lat")]
        public string? Lat { get; set; }

        [JsonPropertyName("lng")]
        public string? Lng { get; set; }
    }
}
