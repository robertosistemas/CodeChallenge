using CodeChallenge.WebApi;
using Xunit;

namespace CodeChallenge.IntegrationsTests.WebApi.Controllers
{
    public class UserControllerCsvTests : UserControllerTests<Startup>, IClassFixture<UserControllerCsvTestsFixture<Startup>>
    {
        public UserControllerCsvTests(SetupFixture setupFixture, UserControllerCsvTestsFixture<Startup> factory) : base(setupFixture, factory)
        {

        }
    }
}
