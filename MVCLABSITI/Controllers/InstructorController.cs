using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Context;
using MVCLABSITI.Models;

namespace MVCLABSITI.Controllers
{
    public class InstructorController : Controller
    {
        SchoolContext db = new SchoolContext();
        public IActionResult getAll()
        {
            var instructors = db.Instructors.ToList();
            return View(instructors);
        }

        public IActionResult getById(int id)
        {
            var instructors = db.Students.Find(id);
            return View(instructors);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNew(Instructor instructor)
        {
            if (instructor.Name != null)
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("getAll");
            }
            return View("Add");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var instructor = db.Instructors.Find(id);
            var departments = db.Departments.ToList();
            ViewBag.departments = departments;
            return View(instructor);
        }
        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            db.Instructors.Update(instructor);
            db.SaveChanges();
            return RedirectToAction("getAll");
        }
    }
}
