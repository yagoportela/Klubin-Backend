using System;
using Microsoft.Extensions.DependencyInjection;
using DadosClientes.Infra.CrossCutting.IoC;
using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace DadosClientes.Application.Init
{
    public static class Startup
    {
        public static ServiceProvider Start(Action<ServiceCollection> configureServices)
        {
            // Set up Dependency Injection
            var serviceCollection = new ServiceCollection();
            configureServices(serviceCollection);   

            var serviceProvider = serviceCollection.BuildServiceProvider();

            ServiceProviderStore.ServiceProvider = serviceProvider;

            return serviceProvider;
        }        
    }
}