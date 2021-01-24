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
    public abstract class UserControllerTests<TStartup> : IntegrateTestBase<TStartup> where TStartup : class
    {
        public UserControllerTests(ApiWebApplicationFactory<TStartup> factory) : base(factory)
        {

        }

        private async Task<string> AddAsync(User user)
        {
            var url = "/User";
            var payload = JsonSerializer.Serialize(user);
            var content = new StringContent(payload, Encoding.UTF8)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };
            var client = Factory.CreateClient();
            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        private async Task UpdateAsync(string userId, User user)
        {
            var url = $"/User/{userId}";
            var payload = JsonSerializer.Serialize(user);
            var content = new StringContent(payload, Encoding.UTF8)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };
            var client = Factory.CreateClient();
            var response = await client.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        private async Task DeleteAsync(string userId)
        {
            var url = $"/User/{userId}";
            var client = Factory.CreateClient();
            var response = await client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        private async Task<User> GetAsync(string userId)
        {
            var url = $"/User/{userId}";
            var client = Factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            User user = null;
            if (!string.IsNullOrWhiteSpace(responseString))
            {
                user = JsonSerializer.Deserialize<User>(responseString);
            }
            return user;
        }

        [Fact]
        public async Task Add_Test_Async()
        {
            var user = new User
            {
                Gender = "m",
                Name = new Name
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
        public async Task Update_Test_Async()
        {
            var user = new User
            {
                Gender = "m",
                Name = new Name
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
        public async Task Delete_Test_Async()
        {
            var user = new User
            {
                Gender = "m",
                Name = new Name
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
        public async Task Get_Test_Async()
        {
            var user = new User
            {
                Gender = "m",
                Name = new Name
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
        public async Task Get_All_Test_Async()
        {
            var url = "/User?Region=sul&Type=laborious";

            //// Exemplo de como mockar um serviço no método
            //var client = Factory.WithWebHostBuilder(builder =>
            //{
            //    builder.ConfigureTestServices(services =>
            //    {
            //        services.AddScoped<IUserServices, UserServicesFake>();
            //    });
            //}).CreateClient();

            var client = Factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var usersResult = JsonSerializer.Deserialize<UsersResult>(responseString);

            usersResult.Users.Count.Should().BeGreaterThan(0);
        }
    }
}
