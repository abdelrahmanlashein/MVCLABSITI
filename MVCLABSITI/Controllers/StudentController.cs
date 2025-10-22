using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLABSITI.Context;
using MVCLABSITI.Filters;
using MVCLABSITI.Models;
using MVCLABSITI.Repositories;
using MVCLABSITI.ViewModels;

namespace MVCLABSITI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IGenericRepository<Student> _studentRepo;
        private readonly IGenericRepository<Department> _departmentRepo;
        private readonly SchoolContext _context;

        public StudentController(
            IGenericRepository<Student> studentRepo, 
            IGenericRepository<Department> departmentRepo,
            SchoolContext context)
        {
            _studentRepo = studentRepo;
            _departmentRepo = departmentRepo;
            _context = context;
        }

        //[AuthorizeFilter(false)]
        public IActionResult getAll()
        {
            var students = _studentRepo.GetAll();
            return View(students);
        }

        public IActionResult getById(int id)
        {
            var student = _studentRepo.GetById(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var departments = _departmentRepo.GetAll();
            ViewBag.departments = departments;
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Student student)
        {
            if (student.DeptId != 0)
            {
                if (ModelState.IsValid)
                {
                    _studentRepo.Add(student);
                    _studentRepo.Save();
                    return RedirectToAction("getAll");
                }
            }
            else
            {
                ModelState.AddModelError("DeptId", "Please select Department");
            }
            
            var departments = _departmentRepo.GetAll();
            ViewBag.departments = departments;
            return View("Add", student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _studentRepo.GetById(id);
            var departments = _departmentRepo.GetAll();
            ViewBag.departments = departments;
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (student.DeptId != 0)
            {
                if (ModelState.IsValid)
                {
                    _studentRepo.Update(student);
                    _studentRepo.Save();
                    return RedirectToAction("getAll");
                }
                else
                {
                    ModelState.AddModelError("DeptId", "Please select Department");
                }
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _studentRepo.GetById(id);
            if (student != null)
            {
                _studentRepo.Delete(student);
                _studentRepo.Save();
            }
            return RedirectToAction("getAll");
        }

        public IActionResult DetailsVM(int id)
        {
            var student = _context.Students
                .Include(s => s.Department)
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefault(s => s.SSN == id);

            if (student == null)
            {
                return NotFound();
            }

            StudentDetailsViewModel studentVM = new StudentDetailsViewModel
            {
                StudentId = student.SSN,
                StudentName = student.Name,
                DepartmentName = student.Department.Name,
                Enrollments = student.Enrollments.ToList()
            };

            return View(studentVM);
        }
    }
}