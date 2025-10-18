using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Context;
using MVCLABSITI.Models;

namespace MVCLABSITI.Controllers
{
    public class CourseController : Controller
    {
        SchoolContext db = new SchoolContext();
        public IActionResult getAll()
        {
            var courses = db.Courses.ToList();
            return View(courses);
        }
        public IActionResult getById(int id)
        {
            var courses = db.Courses.Find(id);
            return View(courses);
        }
        public IActionResult getByName(string name)
        {
            var courses = db.Courses.FirstOrDefault(d => d.Name == name);
            return View(courses);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNew(Course course)
        {
            if (course.Name != null)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("getAll");
            }
            return View("Add");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = db.Courses.Find(id);
            return View(course);
        }
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            db.Courses.Update(course);
            db.SaveChanges();
            return RedirectToAction("getAll");
        }

        public IActionResult Delete(int id)
        {
            var course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("getAll");
        }
    }
}
