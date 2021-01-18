using CodeChallenge.Domain.Abstractions;
using CodeChallenge.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeChallenge.Infrastructure.Data
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly IMemoryCache _cache;
        private readonly string _inputBackEndType;
        private readonly string _inputBackEndCsvUrl;
        private readonly string _inputBackEndJsonUrl;

        public DatabaseContext(IConfiguration configuration, IMemoryCache cache)
        {
            _cache = cache;
            _inputBackEndType = configuration["InputBackEnd:Type"];
            _inputBackEndCsvUrl = configuration["InputBackEnd:CsvUrl"];
            _inputBackEndJsonUrl = configuration["InputBackEnd:JsonUrl"];
        }

        public async Task<List<User>> GetDataAsync()
        {
            if (_inputBackEndType.Equals("csv"))
            {
                return await GetDataFromCsvAsync();
            }
            return await GetDataFromJsonAsync();
        }

        private async Task<string> GeDataFromUrlAsync(string url)
        {
            using var client = new WebClient();
            byte[] content = client.DownloadData(url);
            using var stream = new MemoryStream(content);
            using var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();
            return await Task.FromResult(result);
        }

        private async Task<List<User>> GetDataFromJsonAsync()
        {
            var result = (List<User>)_cache.Get("inputBackEndJsonUrl");
            if (result == null)
            {
                result = new List<User>();
                var json = await GeDataFromUrlAsync(_inputBackEndJsonUrl);
                var usersResult = JsonSerializer.Deserialize<UsersResult>(json);
                foreach (var item in usersResult.Results)
                {
                    var currentItem = item;
                    result.Add(currentItem);
                }
                if (result.Count > 0)
                    _cache.Set("inputBackEndJsonUrl", result);
            }
            return result;
        }

        private async Task<List<User>> GetDataFromCsvAsync()
        {
            var result = (List<User>)_cache.Get("inputBackEndCsvUrl");
            if (result == null)
            {
                result = new List<User>();
                var csv = await GeDataFromUrlAsync(_inputBackEndCsvUrl);
                var itens = csv.Split(Environment.NewLine);
                var count = 0;
                foreach (var item in itens)
                {
                    if (!string.IsNullOrWhiteSpace(item) && count > 0)
                    {
                        var currentItem = item;
                        result.Add(ConvertCsvToUserAsync(currentItem));
                    }
                    count += 1;
                }
                if (result.Count > 0)
                    _cache.Set("inputBackEndCsvUrl", result);
            }
            return result;
        }

        private User ConvertCsvToUserAsync(string currentItem)
        {
            const int gender = 0;
            const int name_title = 1;
            const int name_first = 2;
            const int name_last = 3;
            const int location_street = 4;
            const int location_city = 5;
            const int location_state = 6;
            const int location_postcode = 7;
            const int location_coordinates_latitude = 8;
            const int location_coordinates_longitude = 9;
            const int location_timezone_offset = 10;
            const int location_timezone_description = 11;
            const int email = 12;
            const int dob_date = 13;
            const int dob_age = 14;
            const int registered_date = 15;
            const int registered_age = 16;
            const int phone = 17;
            const int cell = 18;
            const int picture_large = 19;
            const int picture_medium = 20;
            const int picture_thumbnail = 21;

            if (currentItem.StartsWith("\""))
                currentItem = currentItem[1..];

            if (currentItem.EndsWith("\""))
                currentItem = currentItem[0..^1];

            var registro = currentItem.Split("\",\"");

            return new User
            {
                Gender = registro[gender],
                Name = new Name
                {
                    Title = registro[name_title],
                    First = registro[name_first],
                    Last = registro[name_last]
                },
                Location = new Location
                {
                    Street = registro[location_street],
                    City = registro[location_city],
                    State = registro[location_state],
                    Postcode = Convert.ToInt32(registro[location_postcode]),
                    Coordinates = new Coordinates
                    {
                        Latitude = registro[location_coordinates_latitude],
                        Longitude = registro[location_coordinates_longitude]
                    },
                    Timezone = new Timezone
                    {
                        Offset = registro[location_timezone_offset],
                        Description = registro[location_timezone_description]
                    }
                },
                Email = registro[email],
                Dob = new Dob
                {
                    Date = Convert.ToDateTime(registro[dob_date]),
                    Age = Convert.ToInt32(registro[dob_age])
                },
                Registered = new Registered
                {
                    Date = Convert.ToDateTime(registro[registered_date]),
                    Age = Convert.ToInt32(registro[registered_age])
                },
                Phone = registro[phone],
                Cell = registro[cell],
                Picture = new Picture
                {
                    Large = registro[picture_large],
                    Medium = registro[picture_medium],
                    Thumbnail = registro[picture_thumbnail]
                }
            };
        }

    }
}
