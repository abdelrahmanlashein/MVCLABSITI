using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCLABSITI.Filters
{
    public class EditInstructorResultFilter : Attribute, IResultFilter
    {
        private readonly ILogger<EditInstructorResultFilter> _logger;

        public void OnResultExecuted(ResultExecutedContext context)
        {
            var userIp = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            var instructorId = context.RouteData.Values["id"];

            Console.WriteLine($"Instructor {instructorId} was edited by {userIp} at {DateTime.Now}");

            if (context.Controller is Controller controller)
            {
                controller.ViewBag.LastEdited = DateTime.Now.ToString("f");
                controller.ViewBag.userIp = userIp;
                controller.ViewBag.Message = " Instructor details updated successfully.";
            }
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {

        }
    }

}
