using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

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

            InicializeTest(configuration);
        }

        private void InicializeTest(IConfiguration configuration)
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");
            string _outputFileName = configuration["outputFileName"];
            string _fullOutputFileName = $"{AppDomain.CurrentDomain.GetData("DataDirectory")}\\{_outputFileName}";
            if (File.Exists(_fullOutputFileName))
                File.Delete(_fullOutputFileName);
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
