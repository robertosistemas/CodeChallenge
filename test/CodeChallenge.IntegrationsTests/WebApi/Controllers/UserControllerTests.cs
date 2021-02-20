using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Application.Services;
using FluentAssertions;
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
    public abstract class UserControllerTests<TStartup> : IntegrateTestBase<TStartup> where TStartup : class
    {
        public UserControllerTests(ApiWebApplicationFactory<TStartup> factory) : base(factory)
        {

        }

        private static User CreateUser()
        {
            return new User
            {
                Id = System.Guid.NewGuid(),
                Type = "laborious",
                Gender = "m",
                Name = new Name
                {
                    Title = "Mr",
                    First = "Roberto",
                    Last = "Silva"
                },
                Location = new Location
                {
                    Region = "sul",
                    Coordinates = new Coordinates
                    {
                        Latitude = "-2.6880",
                        Longitude = "-146.8402"
                    },
                    Timezone = new Timezone
                    {
                        Description = "Atlantic Time (Canada), Caracas, La Paz",
                        Offset = "-4:00"
                    }
                },
                Picture = new Picture
                {
                    Large = "https://randomuser.me/api/portraits/man/85.jpg",
                    Medium = "https://randomuser.me/api/portraits/med/man/85.jpg",
                    Thumbnail = "https://randomuser.me/api/portraits/thumb/man/85.jpg"
                },
            };
        }

        private async Task<string> AddAsync(User user)
        {
            var userServices = Factory.Services.GetRequiredService<IUserServices>();
            var userId = await userServices.AddAsync(user);
            return userId.ToString();
        }

        private async Task<User?> GetAsync(string userId)
        {
            var userServices = Factory.Services.GetRequiredService<IUserServices>();
            return await userServices.GetAsync(Guid.Parse(userId));
        }

        [Fact]
        public async Task Add_Test_Async()
        {
            var url = "/User";
            var user = CreateUser();
            var payload = JsonSerializer.Serialize(user);
            var content = new StringContent(payload, Encoding.UTF8)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };
            var client = Factory.CreateClient();
            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var userId = await response.Content.ReadAsStringAsync();
            userId.Should().NotBeNullOrEmpty();
            var newUser = await GetAsync(userId);
            Assert.NotNull(newUser);
            if (newUser != null)
                newUser.Id.ToString().Should().Equals(userId);
        }

        [Fact]
        public async Task Update_Test_Async()
        {
            var user = CreateUser();
            var userId = await AddAsync(user);

            var matchedUser = await GetAsync(userId);
            Assert.NotNull(matchedUser);

            if (matchedUser != default)
            {
                if (matchedUser?.Name != default)
                    matchedUser.Name.Last = "Carlos";

                var url = $"/User/{userId}";
                var payload = JsonSerializer.Serialize(matchedUser);
                var content = new StringContent(payload, Encoding.UTF8)
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                };
                var client = Factory.CreateClient();
                var response = await client.PutAsync(url, content);
                response.EnsureSuccessStatusCode();

                var updatedUser = await GetAsync(userId);
                Assert.NotNull(updatedUser);
                if (updatedUser?.Name != default)
                    updatedUser.Name.Last.Should().Equals("Carlos");
            }
        }

        [Fact]
        public async Task Delete_Test_Async()
        {
            var user = CreateUser();
            var userId = await AddAsync(user);

            var url = $"/User/{userId}";
            var client = Factory.CreateClient();
            var response = await client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            var CheckedUser = await GetAsync(userId);
            CheckedUser.Should().BeNull();
        }

        [Fact]
        public async Task Get_Test_Async()
        {
            var user = CreateUser();
            var userId = await AddAsync(user);

            var url = $"/User/{userId}";
            var client = Factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var payload = await response.Content.ReadAsStringAsync();
            payload.Should().NotBeNullOrEmpty();
            if (!string.IsNullOrWhiteSpace(payload))
            {
                User? userMatched = JsonSerializer.Deserialize<User?>(payload);
                userMatched?.Id.ToString().Should().Equals(userId);
            }
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

            var user = CreateUser();
            await AddAsync(user);

            var client = Factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var payload = await response.Content.ReadAsStringAsync();
            var usersResult = JsonSerializer.Deserialize<UsersResult?>(payload);
            Assert.NotNull(usersResult);
            if (usersResult != default)
                usersResult.Users.Count.Should().BeGreaterThan(0);
        }
    }
}
