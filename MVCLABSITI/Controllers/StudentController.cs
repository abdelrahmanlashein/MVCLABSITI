using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLABSITI.Context;
using MVCLABSITI.Models;
using MVCLABSITI.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace MVCLABSITI.Controllers
{
    public class StudentController : Controller
    {
        SchoolContext db = new SchoolContext();
        public IActionResult getAll()
        {
            var students = db.Students.ToList();
            return View(students);
        }

        public IActionResult getById(int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var departments = db.Departments.ToList();
            ViewBag.departments = departments;   // to make dropdown list in student
            return View();
        }
        [HttpPost]  // verb post to receive data from form not from url
        public IActionResult AddNew(Student student)
        {
            if (student.Name != null)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("getAll");
            }
            var departments = db.Departments.ToList(); // adeha ll action tany leh msh fahem?????????
            ViewBag.departments = departments;
            return View("Add", student);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
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

        public IActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("getAll");
        }

        public IActionResult DetailsVM(int id)
        {
            var student = db.Students
                .Include(s => s.Department)
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefault(s => s.SSN == id);
            if (student == null)
            {
                return NotFound(); 
            }
            StudentDetailsViewModel studentVM = new StudentDetailsViewModel();
            studentVM.StudentId = student.SSN;
            studentVM.StudentName = student.Name;
            studentVM.DepartmentName = student.Department.Name;
            studentVM.Enrollments = student.Enrollments.ToList();

            return View(studentVM);
        }

    }
    }
