using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Context;
using MVCLABSITI.Models;

namespace MVCLABSITI.Controllers
{
    public class StudentController : Controller
    {
        SchoolContext db = new SchoolContext();
        public IActionResult getAll()
        {
            var students = db.Students.ToList();
            return View (students);
        }

        public IActionResult getById (int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }
        [HttpGet]
        public IActionResult Add ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("getAll");
        }


    }
}
