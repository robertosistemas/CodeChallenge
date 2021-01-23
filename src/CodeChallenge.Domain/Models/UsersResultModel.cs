using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain.Models
{
    public class UsersResultModel
    {
        public UsersResultModel()
        {
            Users = new List<UserModel>();
        }

        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("users")]
        public List<UserModel> Users { get; set; }
    }
}
