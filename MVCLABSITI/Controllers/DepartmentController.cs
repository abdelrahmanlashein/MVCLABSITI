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
        public IActionResult AddNew(Department department)
        {
            if (department.Name != null)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("getAll");
            }
            return View("Add");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = db.Departments.Find(id);
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
            return RedirectToAction("getAll");
        }

    }
}
