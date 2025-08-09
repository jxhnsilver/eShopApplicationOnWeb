using eShopApplicationOnWeb.Application.Contracts.Identity.Dtos.Auth.Login;
using eShopApplicationOnWeb.Application.Contracts.Identity.Dtos.Auth.Register;
using eShopApplicationOnWeb.Application.Contracts.Identity.Services.Auth;
using eShopApplicationOnWeb.Infrastructure.Identity.Exceptions;
using eShopApplicationOnWeb.Infrastructure.Identity.Models;
using eShopApplicationOnWeb.Infrastructure.Identity.Security.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;

namespace eShopApplicationOnWeb.Infrastructure.Identity.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthService(UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var applicationUser = await _userManager.FindByEmailAsync(request.Email);
            if (applicationUser == null)
                throw new InvalidCredentialsException();

            var isPasswordValid = await _userManager.CheckPasswordAsync(applicationUser, request.Password);
            if (!isPasswordValid)
                throw new InvalidCredentialsException();

            var roles = await _userManager.GetRolesAsync(applicationUser);

            var token = _jwtTokenGenerator.GenerateToken(applicationUser, roles);

            var response = new LoginResponse
            {
                UserId = applicationUser.Id,
                Token = token
            };

            return response;
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

            var createUserResult = await _userManager.CreateAsync(applicationUser, request.Password);
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
