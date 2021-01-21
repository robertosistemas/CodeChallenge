using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Application.Services;
using CodeChallenge.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
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
    }
}
