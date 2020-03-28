using System.Threading.Tasks;
using DadosClientes.Domain.Core.Models;

namespace DadosClientes.Domain.Core.Interfaces.Services
{
    public interface IAuthenticationServices
    {
        Task<string> Register(User user);
        Task<string> SignIn(UserLogin user);
    }
}