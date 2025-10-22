using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Filters;

namespace MVCLABSITI.Controllers
{
    [ExceptionHandleFilter]
    public class FilterTestController : Controller
    {

        public IActionResult Index()
        {
            throw new Exception("Error!");
        }
        public IActionResult Index2()
        {
            throw new Exception("Error2!");
        }
    }
}
