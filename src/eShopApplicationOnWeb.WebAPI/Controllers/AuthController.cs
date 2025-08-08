using eShopApplicationOnWeb.Application.Contracts.Identity.Dtos.Auth.Register;
using eShopApplicationOnWeb.Application.Contracts.Identity.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace eShopApplicationOnWeb.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);

            return StatusCode(StatusCodes.Status201Created, result);
        }
    }
}
