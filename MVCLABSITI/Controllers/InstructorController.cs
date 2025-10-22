using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Context;
using MVCLABSITI.Filters;
using MVCLABSITI.Models;

namespace MVCLABSITI.Controllers
{
    public class InstructorController : Controller
    {
        SchoolContext db = new SchoolContext();
        //[Route("Instructor/All")]

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
            var departments = db.Departments.ToList();
            ViewBag.departments = departments;
            return View();
        }
        [HttpPost]
        public IActionResult AddNew(Instructor instructor)
        {   if (instructor.DeptId != 0)
            {
                if (ModelState.IsValid)
                {
                    db.Instructors.Add(instructor);
                    db.SaveChanges();
                    return RedirectToAction("getAll");
                }
            }
            else
            {
                ModelState.AddModelError("DeptId", "Please select Department");
            }
            
            var departments = db.Departments.ToList();
            ViewBag.departments = departments;
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
        [EditInstructorResultFilter]
        public IActionResult Edit(Instructor instructor)
        {
            if (instructor.DeptId != 0)
            {
                if (ModelState.IsValid)
                {
                    db.Instructors.Update(instructor);
                    db.SaveChanges();
                    return RedirectToAction("getAll");
                }
            }
            else 
            {
                ModelState.AddModelError("DeptId", "Please select Department");
            }
           
            return View(instructor);
        }
        public IActionResult Delete(int id)
        {
            var instructor = db.Instructors.Find(id);
            db.Instructors.Remove(instructor);
            db.SaveChanges();
            return RedirectToAction("getAll");
        }   
    }
}
