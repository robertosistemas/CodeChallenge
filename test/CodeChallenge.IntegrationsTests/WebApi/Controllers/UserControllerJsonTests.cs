using CodeChallenge.WebApi;
using Xunit;

namespace CodeChallenge.IntegrationsTests.WebApi.Controllers
{
    public class UserControllerJsonTests : UserControllerTests<Startup>, IClassFixture<UserControllerJsonTestsFixture<Startup>>
    {
        public UserControllerJsonTests(SetupFixture setupFixture, UserControllerJsonTestsFixture<Startup> factory) : base(setupFixture, factory)
        {

        }
    }
}
