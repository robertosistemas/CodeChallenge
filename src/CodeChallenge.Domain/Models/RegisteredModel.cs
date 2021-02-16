using System;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class RegisteredModel
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; } = default!;

        //[JsonPropertyName("age")]
        //public int Age { get; set; }
    }
}
