using System;

namespace DadosClientes.Domain.Core.Models
{
    public class User : BaseModel
    {
        public string Email {get; set;} 
        public string Password {get; set;}
        public string ConfirmPassword {get; set;}
        public string PhoneNumber {get; set;}
        public string Name {get; set;}
        public string Username {get; set;}
        public string Picture {get; set;}
    }
}