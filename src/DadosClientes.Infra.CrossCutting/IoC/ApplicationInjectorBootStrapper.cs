using AutoMapper;
using DadosClientes.Application.AutoMapper;
using DadosClientes.Domain.Core.Interfaces.Services;
using DadosClientes.Infra.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DadosClientes.Infra.CrossCutting.IoC
{
    public static class ApplicationInjectorBootStrapper
    {
        public static IMvcCoreBuilder AddApplicationModule(this IMvcCoreBuilder builder)
        {            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperUser());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            return builder;
        }

        public static IMvcCoreBuilder AddDependency(this IMvcCoreBuilder builder)
        {
            builder.Services.AddTransient<IAuthenticationServices, AuthenticationServices>();
            return builder;
        }        

    }
}