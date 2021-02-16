using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class PagedModel
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = default!;

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = default!;
    }
}
