using System.Text.Json.Serialization;

namespace Core.Business
{
    public partial class User
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [JsonPropertyName("username")]
        public string? Email { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }

        public User(string? firstName = null, string? lastName = null, string? email = null, string? password = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
