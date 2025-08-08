using eShopApplicationOnWeb.Infrastructure.Identity.Exceptions.Common;
using Microsoft.AspNetCore.Http;

namespace eShopApplicationOnWeb.Infrastructure.Identity.Exceptions
{
    public class EmailAlreadyExistsException : IdentityException
    {
        public override int StatusCode => StatusCodes.Status409Conflict;
        public override string ErrorType => "email_already_exists";

        public EmailAlreadyExistsException(string email)
            : base($"User with email '{email}' already exists") { }
    }
}
