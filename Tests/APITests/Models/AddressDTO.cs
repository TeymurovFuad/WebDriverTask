using System.Text.Json.Serialization;

namespace Tests.APITests.Models
{
    public class AddressDTO: IDTO
    {
        [JsonPropertyName("street")]
        public string? Street { get; set; }

        [JsonPropertyName("suite")]
        public string? Suite { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("zipcode")]
        public string? Zipcode { get; set; }

        [JsonPropertyName("geo")]
        public GeoDTO? Geo { get; set; }
    }
}
