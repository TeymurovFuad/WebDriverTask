using System.Text.Json.Serialization;

namespace Tests.APITests.Models
{
    public class UserDTO: IDTO
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("address")]
        public AddressDTO? Address { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("website")]
        public string? Website { get; set; }

        [JsonPropertyName("company")]
        public CompanyDTO? Company { get; set; }
    }
}
