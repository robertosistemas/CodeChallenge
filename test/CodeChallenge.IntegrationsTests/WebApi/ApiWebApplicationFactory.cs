using Microsoft.AspNetCore.Mvc.Testing;

namespace CodeChallenge.IntegrationsTests.WebApi
{
    public class ApiWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {

    }
}
