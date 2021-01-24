using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeChallenge.IntegrationsTests.WebApi.Controllers
{
    public class UserControllerJsonTestsFixture<TStartup> : ApiWebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            builder.UseConfiguration(configuration);
            builder.ConfigureServices(ConfigureTestServices);
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
