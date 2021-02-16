using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeChallenge.IntegrationsTests.WebApi.Controllers
{
    public class UserControllerCsvTestsFixture<TStartup> : ApiWebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("csv");
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.csv.json")
                .Build();
            builder.UseConfiguration(configuration);
            builder.ConfigureServices(ConfigureTestServices);
            builder.UseSetting("https_port", "5001");
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
