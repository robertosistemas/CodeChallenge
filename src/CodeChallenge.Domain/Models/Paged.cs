using CodeChallenge.Domain.Abstractions;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class Paged : IPaged
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        public void Normalize()
        {
            if (PageNumber <= 0)
                PageNumber = 1;
            if (PageSize <= 0)
                PageSize = 10;
        }

    }
}
