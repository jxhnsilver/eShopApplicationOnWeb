using eShopApplicationOnWeb.Application.Contracts.Infrastructure.Identity.Dtos.Login;
using eShopApplicationOnWeb.Application.Contracts.Infrastructure.Identity.Dtos.Register;

namespace eShopApplicationOnWeb.Application.Contracts.Infrastructure.Identity.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
