using eShopApplicationOnWeb.Application.Contracts.Infrastructure.Identity.Dtos.Auth.Login;
using eShopApplicationOnWeb.Application.Contracts.Infrastructure.Identity.Dtos.Auth.Register;

namespace eShopApplicationOnWeb.Application.Contracts.Infrastructure.Identity.Services.Auth
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
