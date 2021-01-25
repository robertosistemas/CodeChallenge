using System;
using System.IO;

namespace CodeChallenge.IntegrationsTests.WebApi
{
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
}
