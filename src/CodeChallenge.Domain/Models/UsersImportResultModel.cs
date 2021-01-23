using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class UsersImportResultModel
    {
        public UsersImportResultModel()
        {
            Results = new List<UserImportModel>();
        }

        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("results")]
        public List<UserImportModel> Results { get; set; }
    }
}
