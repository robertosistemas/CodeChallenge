namespace CodeChallenge.IntegrationsTests.WebApi
{
    public class IntegrateTestBase<TStartup> : ApiWebApplicationFactory<TStartup> where TStartup : class
    {
        protected readonly ApiWebApplicationFactory<TStartup> Factory;

        public IntegrateTestBase(ApiWebApplicationFactory<TStartup> factory)
        {
            Factory = factory;
        }
    }
}
