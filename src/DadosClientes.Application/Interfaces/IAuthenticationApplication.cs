using System;
using System.Threading.Tasks;
using DadosClientes.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DadosClientes.Application.Interfaces
{
    public interface IAuthenticationApplication
    {
        Task<ActionResult<string>> Register(UserDTO user);
        Task<ActionResult<string>> SignIn(UserLoginDTO user);   
    }
}