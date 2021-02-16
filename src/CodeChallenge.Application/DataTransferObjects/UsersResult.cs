using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodeChallenge.Application.DataTransferObjects
{
    public class UsersResult
    {
        public UsersResult()
        {
            Users = new List<User>();
        }

        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = default!;

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = default!;

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; } = default!;

        [JsonPropertyName("users")]
        public List<User> Users { get; set; }
    }
}
