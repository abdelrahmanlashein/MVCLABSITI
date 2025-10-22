using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Context;
using MVCLABSITI.Filters;
using MVCLABSITI.Models;


namespace MVCLABSITI.Controllers
{
    public class DepartmentController : Controller
    {
        SchoolContext db = new SchoolContext();
        //[Route("Department/All")]
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
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("getAll");
            }
            return View("Add" , department);
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
            if (ModelState.IsValid)
            {
                db.Departments.Update(department);
                db.SaveChanges();
                return RedirectToAction("getAll");
            }
            return View(department);
        }
        public IActionResult Delete(int id) 
        {
            var department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("getAll");
        }
        [HttpGet]
        public IActionResult AddV2()
        {
            return View();
        }

        [HttpPost]
        [LocationValidationFilter]
        public IActionResult AddV2(Department department)
        {
            if (ModelState.IsValid)
            {
                department.DeptId = 0;
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }

            return View(department);
        }
    }
}
