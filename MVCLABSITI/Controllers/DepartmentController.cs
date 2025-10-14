using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Context;
using MVCLABSITI.Models;


namespace MVCLABSITI.Controllers
{
    public class DepartmentController : Controller
    {
        SchoolContext db = new SchoolContext();
        public IActionResult getAll()
        {
            var departments = db.Departments.ToList();
            return View(departments);
        }
        public IActionResult getById(int id)
        {
            var department = db.Departments.Find(id);
            return View(department);
        }
        public IActionResult getByName(string name) 
        {
            var department = db.Departments.FirstOrDefault(d => d.Name == name);
            return View(department);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("getAll");
        }

    }
}
