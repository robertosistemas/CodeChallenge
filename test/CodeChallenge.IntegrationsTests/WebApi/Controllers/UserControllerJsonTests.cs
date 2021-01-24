using CodeChallenge.WebApi;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CodeChallenge.IntegrationsTests.WebApi.Controllers
{
    public class UserControllerJsonTests : UserControllerTests<Startup>, IClassFixture<UserControllerJsonTestsFixture<Startup>>
    {
        public UserControllerJsonTests(UserControllerJsonTestsFixture<Startup> factory) : base(factory)
        {

        }
    }
}
