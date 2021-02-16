using AutoMapper;
using CodeChallenge.Domain.Abstractions;
using CodeChallenge.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CodeChallenge.Infrastructure.Data
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly string _inputBackEndKey;
        private readonly string _inputBackEndType;
        private readonly string _inputBackEndCsvUrl;
        private readonly string _inputBackEndJsonUrl;
        private readonly string _outputFileName;
        private readonly string _fullOutputFileName;
        private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(10);

        public DatabaseContext(IConfiguration configuration, IMapper mapper, IMemoryCache cache)
        {
            _mapper = mapper;
            _inputBackEndKey = "inputBackEndKey";
            _inputBackEndType = configuration["InputBackEnd:Type"];
            _inputBackEndCsvUrl = configuration["InputBackEnd:CsvUrl"];
            _inputBackEndJsonUrl = configuration["InputBackEnd:JsonUrl"];
            _outputFileName = configuration["outputFileName"];
            _fullOutputFileName = $"{AppDomain.CurrentDomain.GetData("DataDirectory")}\\{_outputFileName}";
            _cache = cache;
        }

        public async Task<List<UserModel>> GetDataAsync()
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                if (File.Exists(_fullOutputFileName))
                {
                    return GeDataFromFile();
                }
                if (_inputBackEndType.Equals("csv"))
                {
                    return await GetDataFromCsvAsync();
                }
                return await GetDataFromJsonAsync();
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        public async Task UpdateDataAsync(List<UserModel> users)
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                SaveDataToFile(users);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        private void SaveDataToFile(List<UserModel> users)
        {
            if (File.Exists(_fullOutputFileName))
            {
                File.Delete(_fullOutputFileName);
            }
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var json = JsonSerializer.Serialize(users, typeof(List<UserModel>), options);
            File.WriteAllText(_fullOutputFileName, json, Encoding.GetEncoding(65001));
            UpdateCache(null);
        }

        private List<UserModel> GeDataFromFile()
        {
            var result = ReadCache();
            if (result == null)
            {
                result = new List<UserModel>();
                var options = new JsonSerializerOptions()
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                var json = File.ReadAllText(_fullOutputFileName, Encoding.GetEncoding(65001));
                var resultList = JsonSerializer.Deserialize<List<UserModel>?>(json, options);
                if (resultList != default)
                    result = resultList;
                UpdateCache(result);
            }
            return result;
        }

        private void UpdateCache(List<UserModel>? users)
        {
            if (users == null || !users.Any())
                _cache.Remove(_inputBackEndKey);
            else
                _cache.Set(_inputBackEndKey, users);
        }

        private List<UserModel>? ReadCache()
        {
            return _cache.Get(_inputBackEndKey) as List<UserModel>;
        }

        private static async Task<string> GeDataFromUrlAsync(string url)
        {
            using var client = new WebClient();
            byte[] content = client.DownloadData(url);
            using var stream = new MemoryStream(content);
            using var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();
            return await Task.FromResult(result);
        }

        private async Task<List<UserModel>> GetDataFromJsonAsync()
        {
            var result = ReadCache();
            if (result == null)
            {
                result = new List<UserModel>();
                var json = await GeDataFromUrlAsync(_inputBackEndJsonUrl);
                var usersResult = JsonSerializer.Deserialize<UsersImportResultModel>(json);
                if (usersResult != default)
                {
                    foreach (var item in usersResult.Results)
                    {
                        var currentItem = item;
                        var user = _mapper.Map<UserModel>(currentItem);
                        result.Add(user);
                    }
                }
                SaveDataToFile(result);
                UpdateCache(result);
            }
            return result;
        }

        private async Task<List<UserModel>> GetDataFromCsvAsync()
        {
            var result = ReadCache();
            if (result == null)
            {
                result = new List<UserModel>();
                var csv = await GeDataFromUrlAsync(_inputBackEndCsvUrl);
                var itens = csv.Split(Environment.NewLine);
                var count = 0;
                foreach (var item in itens)
                {
                    if (!string.IsNullOrWhiteSpace(item) && count > 0)
                    {
                        var currentItem = ConvertCsvToUserAsync(item);
                        var user = _mapper.Map<UserModel>(currentItem);
                        result.Add(user);
                    }
                    count += 1;
                }
                SaveDataToFile(result);
                UpdateCache(result);
            }
            return result;
        }

        private const int GENDER = 0;
        private const int NAME_TITLE = 1;
        private const int NAME_FIRST = 2;
        private const int NAME_LAST = 3;
        private const int LOCATION_STREET = 4;
        private const int LOCATION_CITY = 5;
        private const int LOCATION_STATE = 6;
        private const int LOCATION_POSTCODE = 7;
        private const int LOCATION_COORDINATES_LATITUDE = 8;
        private const int LOCATION_COORDINATES_LONGITUDE = 9;
        private const int LOCATION_TIMEZONE_OFFSET = 10;
        private const int LOCATION_TIMEZONE_DESCRIPTION = 11;
        private const int EMAIL = 12;
        private const int DOB_DATE = 13;
        private const int DOB_AGE = 14;
        private const int REGISTERED_DATE = 15;
        private const int REGISTERED_AGE = 16;
        private const int PHONE = 17;
        private const int CELL = 18;
        private const int PICTURE_LARGE = 19;
        private const int PICTURE_MEDIUM = 20;
        private const int PICTURE_THUMBNAIL = 21;

        private static UserImportModel ConvertCsvToUserAsync(string currentItem)
        {
            if (currentItem.StartsWith("\""))
                currentItem = currentItem[1..];

            if (currentItem.EndsWith("\""))
                currentItem = currentItem[0..^1];

            var record = currentItem.Split("\",\"");

            return new UserImportModel
            {
                Gender = record[GENDER],
                Name = new NameModel
                {
                    Title = record[NAME_TITLE],
                    First = record[NAME_FIRST],
                    Last = record[NAME_LAST]
                },
                Location = new LocationModel
                {
                    Street = record[LOCATION_STREET],
                    City = record[LOCATION_CITY],
                    State = record[LOCATION_STATE],
                    Postcode = Convert.ToInt32(record[LOCATION_POSTCODE]),
                    Coordinates = new CoordinatesModel
                    {
                        Latitude = record[LOCATION_COORDINATES_LATITUDE],
                        Longitude = record[LOCATION_COORDINATES_LONGITUDE]
                    },
                    Timezone = new TimezoneModel
                    {
                        Offset = record[LOCATION_TIMEZONE_OFFSET],
                        Description = record[LOCATION_TIMEZONE_DESCRIPTION]
                    }
                },
                Email = record[EMAIL],
                Dob = new DobModel
                {
                    Date = Convert.ToDateTime(record[DOB_DATE]),
                    //Age = Convert.ToInt32(record[DOB_AGE])
                },
                Registered = new RegisteredModel
                {
                    Date = Convert.ToDateTime(record[REGISTERED_DATE]),
                    //Age = Convert.ToInt32(record[REGISTERED_AGE])
                },
                Phone = record[PHONE],
                Cell = record[CELL],
                Picture = new PictureModel
                {
                    Large = record[PICTURE_LARGE],
                    Medium = record[PICTURE_MEDIUM],
                    Thumbnail = record[PICTURE_THUMBNAIL]
                }
            };
        }
    }
}
