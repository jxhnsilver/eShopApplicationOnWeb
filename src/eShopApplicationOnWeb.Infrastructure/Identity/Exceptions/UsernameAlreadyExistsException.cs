using eShopApplicationOnWeb.Infrastructure.Identity.Exceptions.Common;
using Microsoft.AspNetCore.Http;

namespace eShopApplicationOnWeb.Infrastructure.Identity.Exceptions
{
    public class UsernameAlreadyExistsException : IdentityException
    {
        public override int StatusCode => StatusCodes.Status409Conflict;
        public override string ErrorType => "username_already_exists";
        public UsernameAlreadyExistsException(string username)
            : base($"Username '{username}' is already exists") { }
    }
}
