using System;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class Dob
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}
