using eShopApplicationOnWeb.Infrastructure.Identity.Exceptions.Common;
using Microsoft.AspNetCore.Http;

namespace eShopApplicationOnWeb.Infrastructure.Identity.Exceptions
{
    public class InvalidCredentialsException : IdentityException
    {
        public override int StatusCode => StatusCodes.Status401Unauthorized;
        public override string ErrorType => "invalid_credentials";
        public InvalidCredentialsException() 
            : base("Invalid credentials") { }
    }
}
