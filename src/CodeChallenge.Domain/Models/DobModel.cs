using System;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class DobModel
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; } = default!;

        //[JsonPropertyName("age")]
        //public int Age { get; set; }
    }
}
