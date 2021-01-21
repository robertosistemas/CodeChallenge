using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Application.Services;
using CodeChallenge.Domain.Models;
using CodeChallenge.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CodeChallenge.IntegrationsTests.WebApi.Controllers
{
    public class UserControllerTests : IntegrateTestBase<Startup>, IClassFixture<UserControllerTestsFixture<Startup>>
    {

        public UserControllerTests(UserControllerTestsFixture<Startup> factory) : base(factory)
        {
        }

        private async Task<string> AddAsync(UserDto userDto)
        {
            var url = "/User";
            var payload = JsonSerializer.Serialize(userDto);
            var content = new StringContent(payload, Encoding.UTF8)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };
            var _client = Factory.CreateClient();
            var response = await _client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        private async Task UpdateAsync(string userId, UserDto userDto)
        {
            var url = $"/User/{userId}";
            var payload = JsonSerializer.Serialize(userDto);
            var content = new StringContent(payload, Encoding.UTF8)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };
            var _client = Factory.CreateClient();
            var response = await _client.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        private async Task DeleteAsync(string userId)
        {
            var url = $"/User/{userId}";
            var _client = Factory.CreateClient();
            var response = await _client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        private async Task<UserDto> GetAsync(string userId)
        {
            var url = $"/User/{userId}";
            var _client = Factory.CreateClient();
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            UserDto user = null;
            if (!string.IsNullOrWhiteSpace(responseString))
            {
                user = JsonSerializer.Deserialize<UserDto>(responseString);
            }
            return user;
        }

        [Fact]
        public async Task Test_AddAsync()
        {
            var user = new UserDto
            {
                Gender = "m",
                Name = new NameDto
                {
                    Title = "Mr",
                    First = "Roberto",
                    Last = "Silva"
                }
            };
            var responseString = await AddAsync(user);
            responseString.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Test_UpdateAsync()
        {
            var user = new UserDto
            {
                Gender = "m",
                Name = new NameDto
                {
                    Title = "Mr",
                    First = "Roberto",
                    Last = "Silva"
                }
            };
            var userId = await AddAsync(user);

            var matchedUser = await GetAsync(userId);
            matchedUser.Name.Last = "Carlos";
            await UpdateAsync(userId, matchedUser);

            var updatedUser = await GetAsync(userId);
            updatedUser.Name.Last.Should().Equals("Carlos");
        }

        [Fact]
        public async Task Test_DeleteAsync()
        {
            var user = new UserDto
            {
                Gender = "m",
                Name = new NameDto
                {
                    Title = "Mr",
                    First = "Roberto",
                    Last = "Silva"
                }
            };
            var userId = await AddAsync(user);
            await DeleteAsync(userId);
            var CheckedUser = await GetAsync(userId);
            CheckedUser.Should().BeNull();
        }

        [Fact]
        public async Task Test_GetAsync()
        {
            var user = new UserDto
            {
                Gender = "m",
                Name = new NameDto
                {
                    Title = "Mr",
                    First = "Roberto",
                    Last = "Silva"
                }
            };
            var userId = await AddAsync(user);

            var userMatched = await GetAsync(userId);

            userMatched.Id.ToString().Should().Equals(userId);
        }

        [Fact]
        public async Task Test_GetAllAsync()
        {
            var url = "/User?Region=sul&Type=laborious&PageNumber=1&PageSize=10";

            //// Mockando um serviço no método
            //var _client = Factory.WithWebHostBuilder(builder =>
            //{
            //    builder.ConfigureTestServices(services =>
            //    {
            //        services.AddScoped<IUserServices, UserServicesFake>();
            //    });
            //}).CreateClient();

            var _client = Factory.CreateClient();
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var usersResult = JsonSerializer.Deserialize<UsersResultDto>(responseString);

            usersResult.Users.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Test_Mapeamento()
        {
            // Arrange

            var userImport = new UserImport
            {
                Gender = "male",
                Name = new Name
                {
                    Title = "Mr",
                    First = "Roberto",
                    Last = "Silva"
                },
                Location = new Location
                {
                    Street = "Rua Teste",
                    City = "Floripa",
                    State = "santa catarina",
                    Postcode = 12345789,
                    Coordinates = new Coordinates
                    {
                        Latitude = "-76.3253",
                        Longitude = "137.9437"
                    },
                    Timezone = new Timezone
                    {
                        Offset = "-1:00",
                        Description = "Azores, Cape Verde Islands"
                    }
                },
                Email = "ione.dacosta@example.com",
                Dob = new Dob
                {
                    Date = Convert.ToDateTime("1968-01-24T18:03:23Z"),
                    Age = 50
                },
                Registered = new Registered
                {
                    Date = Convert.ToDateTime("2004-01-23T23:54:33Z"),
                    Age = 14
                },
                Phone = "(01) 5415-5648",
                Cell = "(10) 8264-5550",
                Picture = new Picture
                {
                    Large = "https://randomuser.me/api/portraits/women/46.jpg",
                    Medium = "https://randomuser.me/api/portraits/med/women/46.jpg",
                    Thumbnail = "https://randomuser.me/api/portraits/thumb/women/46.jpg"
                }
            };

            //Act

            var mapper = Factory.Services.GetService<IMapper>();
            var user = mapper.Map<User>(userImport);

            // Assert

            user.Id.Should().NotBeEmpty();
            user.Type.Should().Be("laborious");
            user.Gender.Should().Be("m");

            user.Birthday.Should().Be(Convert.ToDateTime("1968-01-24T18:03:23Z"));
            user.Registered.Should().Be(Convert.ToDateTime("2004-01-23T23:54:33Z"));

            user.TelephoneNumbers.Count.Should().Be(1);
            user.TelephoneNumbers[0].Should().Be("+550154155648");

            user.MobileNumbers.Count.Should().Be(1);
            user.MobileNumbers[0].Should().Be("+551082645550");

            user.Nationality.Should().Be("BR");
            user.Location.Region.Should().Be("sul");

        }
    }
}
