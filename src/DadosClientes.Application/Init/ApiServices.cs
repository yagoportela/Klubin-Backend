using System;
using System.IO;
using DadosClientes.Infra.CrossCutting.IoC;
using Microsoft.Extensions.Configuration;

namespace DadosClientes.Application.Init {
    public class ApiServices {
        public static IServiceProvider ServiceProvider { get; } =
        Startup.Start (serviceCollection => {
            DependencyInjection.ConfigureServices (serviceCollection);
            DependencyInjection.AddDependency (serviceCollection);
        });
    }
}