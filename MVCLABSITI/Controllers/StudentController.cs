using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Context;
using MVCLABSITI.Models;
using System.Reflection.Metadata.Ecma335;

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
        public IActionResult AddNew(Student student)
        {
            if (student.Name != null)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("getAll");
            }
            return View("Add");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = db.Students.Find (id);
            var departments = db.Departments.ToList();
            ViewBag.departments = departments;
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
                db.Students.Update(student);
                db.SaveChanges();
                return RedirectToAction("getAll");
        }




    }
}
