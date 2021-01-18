using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class User
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }

        [JsonPropertyName("registered")]
        public DateTime Registered { get; set; }

        [JsonPropertyName("telephoneNumbers")]
        public List<string> TelephoneNumbers { get; set; }

        [JsonPropertyName("mobileNumbers")]
        public List<string> MobileNumbers { get; set; }

        [JsonPropertyName("picture")]
        public Picture Picture { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }
    }
}
