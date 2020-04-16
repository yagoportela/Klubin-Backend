using System.Threading.Tasks;
using AutoMapper;
using DadosClientes.Application.Init;
using DadosClientes.Application.Interfaces;
using DadosClientes.Domain.Core.Dto.DadosClientes;
using DadosClientes.Domain.Core.Interfaces.Services;
using DadosClientes.Domain.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DadosClientes.Application.Services {

    [ApiController]
    public class AuthenticationApplication: ControllerBase, IAuthenticationApplication {
        private readonly IAuthenticationServices _authenticationServices;
        private readonly IMapper _mapper;

        public AuthenticationApplication () : this (ApiServices.ServiceProvider.GetService<IMapper>(),
                                                    ApiServices.ServiceProvider.GetService<IAuthenticationServices>()) { }

        public AuthenticationApplication (IMapper mapper,
                                          IAuthenticationServices authenticationServices) {
            _mapper = mapper;
            _authenticationServices = authenticationServices;
        }
        public object Valor () {      
            var resultado = new {
                    isBase64Encoded= false,
                    statusCode= 200,
                    headers= new { headerName= "headerValue"},
                    body= _authenticationServices.teste()
                };
                
             return resultado;
        }

        public async Task<ActionResult<string>> Register ([FromBody] UserDTO userDto) {
            var user = _mapper.Map<User> (userDto);
            var register = await _authenticationServices.Register (user);
            return register;
        }
        
        public async Task<ActionResult<string>> SignIn ([FromBody] UserLoginDTO userLoginDto) {
            var userLogin = _mapper.Map<UserLogin> (userLoginDto);
            var register = await _authenticationServices.SignIn (userLogin);
            return register;
        }
    }
}