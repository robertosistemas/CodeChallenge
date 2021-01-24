namespace CodeChallenge.IntegrationsTests.WebApi
{
    public abstract class IntegrateTestBase<TStartup> where TStartup : class
    {
        protected ApiWebApplicationFactory<TStartup> Factory;

        public IntegrateTestBase(ApiWebApplicationFactory<TStartup> factory)
        {
            Factory = factory;
        }
    }
}
