using eShopApplicationOnWeb.Infrastructure.Identity.Exceptions.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace eShopApplicationOnWeb.Infrastructure.Identity.Exceptions
{
    public class IdentityOperationFailedException : IdentityException
    {
        public override int StatusCode => StatusCodes.Status422UnprocessableEntity;
        public override string ErrorType => "identity_operation_failed";
        public IdentityOperationFailedException(IEnumerable<IdentityError> errors) 
            : base($"Identity error: {string.Join(", ", errors.Select(e => e.Description))}") { }
    }
}
