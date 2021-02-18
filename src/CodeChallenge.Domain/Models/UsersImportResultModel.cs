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

        [JsonPropertyName("results")]
        public List<UserImportModel> Results { get; set; } = null!;
    }
}
