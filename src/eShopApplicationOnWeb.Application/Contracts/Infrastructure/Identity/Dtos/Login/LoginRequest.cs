using System.ComponentModel.DataAnnotations;

namespace eShopApplicationOnWeb.Application.Contracts.Infrastructure.Identity.Dtos.Login
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
