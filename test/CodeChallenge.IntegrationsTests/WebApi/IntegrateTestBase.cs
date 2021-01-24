using System;
using System.IO;
using Xunit;

namespace CodeChallenge.IntegrationsTests.WebApi
{
    [Collection("Setup collection")]
    public abstract class IntegrateTestBase<TStartup> where TStartup : class
    {
        protected SetupFixture SetupFixture;
        protected ApiWebApplicationFactory<TStartup> Factory;

        public IntegrateTestBase(SetupFixture setupFixture, ApiWebApplicationFactory<TStartup> factory)
        {
            Factory = factory;
            SetupFixture = setupFixture;
        }
    }

    public class SetupFixture : IDisposable
    {
        public SetupFixture()
        {
            // ... initialize data in the test ...
            var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
#if DEBUG
            var appPath = directoryInfo.Parent.Parent.Parent.Parent.Parent.FullName;
#else
            var appPath = directoryInfo.FullName;
#endif
            var csvFile = Path.Combine(appPath, "src\\CodeChallenge.WebApi\\wwwroot\\App_Data\\output-backend.json");
            if (File.Exists(csvFile))
                File.Delete(csvFile);

            var JsonFile = Path.Combine(appPath, "src\\CodeChallenge.WebApi\\wwwroot\\App_Data\\output-backend-csv.json");
            if (File.Exists(JsonFile))
                File.Delete(JsonFile);
        }

        public void Dispose()
        {
            // ... clean up test data ...
        }

    }

    [CollectionDefinition("Setup collection")]
    public class SetupCollection : ICollectionFixture<SetupFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
