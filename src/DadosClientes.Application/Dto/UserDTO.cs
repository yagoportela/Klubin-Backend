using System;

namespace DadosClientes.Application.Dto
{
    public class UserDTO
    {
        public Guid id {get; set;}
        public string email {get; set;} 
        public string Password {get; set;}
        public string ConfirmPassword {get; set;}
        public string phoneNumber {get; set;}
        public string name {get; set;}
        public string username {get; set;}
        public string picture {get; set;}
    }
}