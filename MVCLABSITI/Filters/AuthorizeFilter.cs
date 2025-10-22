using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCLABSITI.Filters
{
    public class AuthorizeFilter : Attribute, IAuthorizationFilter
    {
        private bool _isAuthorized; 
        public AuthorizeFilter(bool isAuthorized)
        {
            _isAuthorized = isAuthorized;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!_isAuthorized)
            {
                context.Result = new ViewResult()
                {
                    ViewName = "Unauthorized",
                    StatusCode = 403
                };
            }

        }
    }
}
