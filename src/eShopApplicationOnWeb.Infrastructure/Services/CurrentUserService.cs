using eShopApplicationOnWeb.Application.Contracts.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace eShopApplicationOnWeb.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier);

            return userIdClaim?.Value;
        }
    }
}
