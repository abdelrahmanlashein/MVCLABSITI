using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVCLABSITI.Models;

namespace MVCLABSITI.Filters
{
    public class LocationValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("department"))
            {
                var department = context.ActionArguments["department"] as Department;

                if (department != null)
                {
                    if (string.IsNullOrEmpty(department.Location))
                    {
                        context.ModelState.AddModelError("Location", "Location is required");
                        context.Result = new BadRequestObjectResult(context.ModelState);
                        return;
                    }

                    if (department.Location != "EG" && department.Location != "USA")
                    {
                        context.ModelState.AddModelError("Location",
                            "Location must be either 'EG' or 'USA'");

                        context.Result = new ViewResult
                        {
                            ViewName = "AddV2",
                            ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(
                                new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(),
                                context.ModelState)
                            {
                                Model = department
                            }
                        };
                        return;
                    }
                }
            }

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Optional - after action executes
            base.OnActionExecuted(context);
        }
    }

}
