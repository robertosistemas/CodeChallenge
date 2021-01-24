using CodeChallenge.WebApi;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Xunit;

namespace CodeChallenge.IntegrationsTests.WebApi.Controllers
{
    public class UserControllerCsvTests : UserControllerTests<Startup>, IClassFixture<UserControllerCsvTestsFixture<Startup>>
    {
        public UserControllerCsvTests(UserControllerCsvTestsFixture<Startup> factory) : base(factory)
        {

        }
    }
}
