using Microsoft.AspNetCore.Http;

namespace eShopApplicationOnWeb.Infrastructure.Identity.Exceptions.Common
{
    public class IdentityException : Exception
    {
        public virtual int StatusCode => StatusCodes.Status400BadRequest;
        public virtual string ErrorType => "identity_error";
        protected IdentityException(string message) 
            : base(message) { }
    }
}
