using CodeChallenge.Domain.Abstractions;
using CodeChallenge.IntegrationsTests.Mocks;
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
        }

        /// <summary>
        /// Utilize para mockar seviços
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureTestServices(IServiceCollection services)
        {
            services.AddSingleton<IDatabaseContext, DatabaseContextFake>();
        }
    }
}
