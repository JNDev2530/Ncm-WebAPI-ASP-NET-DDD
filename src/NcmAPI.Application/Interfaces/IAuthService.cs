using System.Threading.Tasks;

namespace NcmAPI.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(string username, string password);
        Task RegisterAsync(string username, string password);
    }
}