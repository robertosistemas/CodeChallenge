using Xunit;

namespace CodeChallenge.IntegrationsTests.WebApi
{
    [CollectionDefinition("Setup collection")]
    public class SetupCollection : ICollectionFixture<SetupFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
