using Amazon.Lambda.AspNetCoreServer;
using Amazon.Lambda.Core;
using Microsoft.AspNetCore.Hosting;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace DadosClientes {
    public class LambdaEntryPoint : APIGatewayProxyFunction {
        protected override void Init (IWebHostBuilder builder) {
            builder.UseStartup<Startup>();
        }

    }
}