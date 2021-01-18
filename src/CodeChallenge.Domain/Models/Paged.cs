using CodeChallenge.Domain.Abstractions;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class Paged: IPaged
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }
    }
}
