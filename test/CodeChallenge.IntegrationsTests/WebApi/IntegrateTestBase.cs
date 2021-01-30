using Xunit;

namespace CodeChallenge.IntegrationsTests.WebApi
{
    [Collection("Setup collection")]
    public abstract class IntegrateTestBase<TStartup> where TStartup : class
    {
        //protected SetupFixture SetupFixture;
        protected ApiWebApplicationFactory<TStartup> Factory;

        public IntegrateTestBase(ApiWebApplicationFactory<TStartup> factory)
        {
            Factory = factory;
        }
    }
}
