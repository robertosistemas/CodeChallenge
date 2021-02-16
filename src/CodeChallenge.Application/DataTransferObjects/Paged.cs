using CodeChallenge.Domain.Abstractions;
using System.Text.Json.Serialization;

namespace CodeChallenge.Application.DataTransferObjects
{
    public class Paged : IPaged
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = default!;

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = default!;

        public void Normalize()
        {
            if (PageNumber <= 0)
                PageNumber = 1;
            if (PageSize <= 0)
                PageSize = 10;
        }
    }
}
