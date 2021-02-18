﻿using System.Collections.Generic;
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
        public int PageNumber { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("users")]
        public List<User> Users { get; set; } = null!;
    }
}
