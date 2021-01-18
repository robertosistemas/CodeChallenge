using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class UsersImportResult
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("results")]
        public List<UserImport> Results { get; set; }
    }
}
