using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CodeChallenge.IntegrationsTests.WebApi
{
    public class ApiWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public ApiWebApplicationFactory()
        {

        }
    }
}
