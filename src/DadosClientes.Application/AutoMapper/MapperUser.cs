using AutoMapper;
using DadosClientes.Application.Dto;
using DadosClientes.Domain.Core.Models;

namespace DadosClientes.Application.AutoMapper {
    public class MapperUser : Profile {

        public MapperUser () {
            CreateMap<UserDTO, User>();
            CreateMap<UserLoginDTO, UserLogin>();
        }
    }
}