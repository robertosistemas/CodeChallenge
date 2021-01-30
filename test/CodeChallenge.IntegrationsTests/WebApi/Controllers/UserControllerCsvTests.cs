using CodeChallenge.WebApi;
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
