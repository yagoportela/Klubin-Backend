using System.Threading.Tasks;
using AutoMapper;
using DadosClientes.Application.Dto;
using DadosClientes.Application.Interfaces;
using DadosClientes.Domain.Core.Interfaces.Services;
using DadosClientes.Domain.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DadosClientes.Application.Services
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationApplication : ControllerBase, IAuthenticationApplication
    {
        private readonly IAuthenticationServices _authenticationServices;
        private readonly IMapper _mapper;

        public AuthenticationApplication(IMapper mapper,
                                         IAuthenticationServices authenticationServices) {
            _mapper = mapper;
            _authenticationServices = authenticationServices ;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> Register(UserDTO userDto)
        {            
            var user = _mapper.Map<User>(userDto);
            var register = await _authenticationServices.Register(user);
            return register;
        }

        [HttpPost]
        [Route("signin")]
        public async Task<ActionResult<string>> SignIn([FromBody]UserLoginDTO userLoginDto)
        {
            var userLogin = _mapper.Map<UserLogin>(userLoginDto);
            var register = await _authenticationServices.SignIn(userLogin);
            return Ok(register);
        }
    }
}