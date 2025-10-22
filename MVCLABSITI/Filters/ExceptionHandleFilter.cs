using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCLABSITI.Filters
{
    public class ExceptionHandleFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult res = new ViewResult();
            res.ViewName = "Error";
            context.Result = res;
        }
    }
}
