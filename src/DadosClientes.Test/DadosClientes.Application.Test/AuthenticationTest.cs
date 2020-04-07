using System;
using System.Threading.Tasks;
using DadosClientes.Application.Services;
using DadosClientes.Domain.Core.Dto.DadosClientes;
using Xunit;

namespace DadosClientes.Application.Test {
    public class AuthenticationTest {

        [Fact]
        public async Task RegisterTest () {

            try {
                AuthenticationApplication authentication = new AuthenticationApplication ();

                var user = new UserDTO () {
                    id = Guid.NewGuid (),
                    email = "teste@teste.vom",
                    Password = "Teste12345",
                    ConfirmPassword = "Teste12345",
                    phoneNumber = "+5511953684990",
                    name = "Teste",
                    username = "Teste",
                    picture = "teste"
                };

                var valor = authentication.Valor();

                Console.WriteLine (valor);

            } catch (Exception ex) {
                Console.WriteLine (ex.Message);
            }

        }

    }
}