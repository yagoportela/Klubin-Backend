using System.IO;
using AutoMapper;
using DadosClientes.Domain.Core.Dto.Configuration;
using DadosClientes.Domain.Core.Interfaces.Services;
using DadosClientes.Infra.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DadosClientes.Infra.CrossCutting.IoC {
    public static class DependencyInjection {
        public static void ConfigureMapper (IServiceCollection builder) {

            builder.AddMvc(options =>
            {
                options.RequireHttpsPermanent = true; 
                options.RespectBrowserAcceptHeader = true;
            });

            var mappingConfig = new MapperConfiguration (mc => {
                mc.AddProfile (new AutoMapper ());
            });

            IMapper mapper = mappingConfig.CreateMapper ();

            builder.AddSingleton (mapper);            

        }

        public static void AddDependency (IServiceCollection builder) {
            builder.AddTransient<IAuthenticationServices, AuthenticationServices> ();
        }

        public static void ConfigurationEnvironment (IServiceCollection builder) {            
            builder.AddSingleton<Authorization> (Configuration.GetConfiguration()
                                                              .GetSection("Authorization")
                                                              .Get<Authorization>());

        }

    }

}