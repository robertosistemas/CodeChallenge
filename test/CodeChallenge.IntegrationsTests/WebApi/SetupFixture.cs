using System;
using System.IO;

namespace CodeChallenge.IntegrationsTests.WebApi
{
    public class SetupFixture : IDisposable
    {
        private bool disposedValue;

        public SetupFixture()
        {
            // ... initialize data in the test ...
#if DEBUG
            var appPath = new DirectoryInfo(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.Parent?.Parent?.FullName;
#else
            var appPath = new DirectoryInfo(Directory.GetCurrentDirectory()).FullName;
#endif
            var csvFile = Path.Combine($"{appPath}", "src\\CodeChallenge.WebApi\\wwwroot\\App_Data\\output-backend.json");
            if (File.Exists(csvFile))
                File.Delete(csvFile);

            var JsonFile = Path.Combine($"{appPath}", "src\\CodeChallenge.WebApi\\wwwroot\\App_Data\\output-backend-csv.json");
            if (File.Exists(JsonFile))
                File.Delete(JsonFile);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~SetupFixture()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
