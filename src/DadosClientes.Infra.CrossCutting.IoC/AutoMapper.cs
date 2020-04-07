using AutoMapper;
using DadosClientes.Domain.Core.Dto.DadosClientes;
using DadosClientes.Domain.Core.Models;

namespace DadosClientes.Infra.CrossCutting.IoC 
{
    public class AutoMapper : Profile {

        public AutoMapper () {
            CreateMap<UserDTO, User>();
            CreateMap<UserLoginDTO, UserLogin>();
        }
    }
}