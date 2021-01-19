using CodeChallenge.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace CodeChallenge.IntegrationsTests.WebApi
{
    public class IntegrateTestBase
    {

        protected readonly TestServer _server;
        protected readonly HttpClient _client;

        public IntegrateTestBase()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Test")
                .UseConfiguration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build())
                .UseStartup<Startup>());

            _client = _server.CreateClient();
        }
    }
}
