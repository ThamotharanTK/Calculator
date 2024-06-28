using Calculator.Domain.Entities;
using System.Threading.Tasks;

namespace Calculator.Application.Services
{
    public interface IAuthService
    {
        Task<string> GenerateToken(User user);
        Task<string> GenerateRefreshToken();
    }
}
