using System.IO;
using Microsoft.Extensions.Configuration;

namespace DadosClientes.Infra.CrossCutting.IoC {
    public static class Configuration {
        public static IConfiguration GetConfiguration () {
            return new ConfigurationBuilder ()
                .SetBasePath (Directory.GetCurrentDirectory ())
                .AddJsonFile ("appsettings.json", optional : false, reloadOnChange : true)
                .AddEnvironmentVariables ()
                .Build ();
        }

    }
}