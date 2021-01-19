using CodeChallenge.Application.DataTransferObjects;
using FluentAssertions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CodeChallenge.IntegrationsTests.WebApi.Controllers
{
    public class UserControllerTests : IntegrateTestBase
    {
        public UserControllerTests()
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
            var response = await _client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        private async Task UpdateAsync(string guid, UserDto userDto)
        {
            var url = $"/User/{guid}";
            var payload = JsonSerializer.Serialize(userDto);
            var content = new StringContent(payload, Encoding.UTF8)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };
            var response = await _client.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        private async Task DeleteAsync(string guid)
        {
            var url = $"/User/{guid}";
            var response = await _client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        private async Task<UserDto> GetAsync(string guid)
        {
            var url = $"/User/{guid}";
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
            // Assert
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
            var guid = await AddAsync(user);

            var matchedUser = await GetAsync(guid);
            matchedUser.Name.Last = "Carlos";
            await UpdateAsync(guid, matchedUser);

            // Assert
            var updatedUser = await GetAsync(guid);
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
            var guid = await AddAsync(user);
            await DeleteAsync(guid);
            var CheckedUser = await GetAsync(guid);
            // Assert
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
            var guid = await AddAsync(user);

            var userMatched = await GetAsync(guid);
            // Assert
            userMatched.Id.ToString().Should().Equals(guid);
        }

        [Fact]
        public async Task Test_GetAllAsync()
        {
            // Arrange
            var url = "/User?Region=sul&Type=laborious&PageNumber=1&PageSize=10";

            // Act
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            responseString.Should().NotBeNullOrEmpty();
        }

    }
}
