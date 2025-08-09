using eShopApplicationOnWeb.Infrastructure.Identity.Models;

namespace eShopApplicationOnWeb.Infrastructure.Identity.Security.Tokens.Jwt
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IList<string> roles);
    }
}
