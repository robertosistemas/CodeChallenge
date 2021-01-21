using CodeChallenge.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeChallenge.IntegrationsTests.WebApi.Controllers
{
    public class UserControllerTestsFixture<TStartup> : ApiWebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(ConfigureTestServices);

            builder.UseEnvironment("Test");
            builder.UseConfiguration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build());
        }

        /// <summary>
        /// Utilize para mockar seviços
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureTestServices(IServiceCollection services)
        {
            // services.AddScoped<IUserServices, UserServicesFake>();
        }
    }
}
