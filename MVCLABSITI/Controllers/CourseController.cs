using Microsoft.AspNetCore.Mvc;

namespace MVCLABSITI.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
