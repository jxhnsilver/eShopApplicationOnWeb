using eShopApplicationOnWeb.Application.Contracts.Identity.Dtos.Auth.Register;
using eShopApplicationOnWeb.Application.Contracts.Identity.Services.Auth;
using eShopApplicationOnWeb.Infrastructure.Identity.Exceptions;
using eShopApplicationOnWeb.Infrastructure.Identity.Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace eShopApplicationOnWeb.Infrastructure.Identity.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _userManager.FindByEmailAsync(request.Email) is not null)
                throw new EmailAlreadyExistsException(request.Email);

            if (await _userManager.FindByNameAsync(request.Username) is not null)
                throw new UsernameAlreadyExistsException(request.Username);

            var applicationUser = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            var createUserResult = await _userManager.CreateAsync(applicationUser);

            if (!createUserResult.Succeeded)
                throw new IdentityOperationFailedException(createUserResult.Errors);

            var addRoleResult = await _userManager.AddToRoleAsync(applicationUser, "User");

            if (!addRoleResult.Succeeded)
                throw new IdentityOperationFailedException(createUserResult.Errors);

            var response = new RegisterResponse
            {
                UserId = applicationUser.Id,
                Email = applicationUser.Email
            };

            return response;
        }
    }
}
