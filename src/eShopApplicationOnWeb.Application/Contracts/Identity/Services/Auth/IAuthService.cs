using eShopApplicationOnWeb.Application.Contracts.Identity.Dtos.Auth.Register;

namespace eShopApplicationOnWeb.Application.Contracts.Identity.Services.Auth
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
    }
}
