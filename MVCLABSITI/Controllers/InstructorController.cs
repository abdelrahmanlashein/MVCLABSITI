using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Filters;
using MVCLABSITI.Models;
using MVCLABSITI.Repositories;

namespace MVCLABSITI.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IGenericRepository<Instructor> _instructorRepo;
        private readonly IGenericRepository<Department> _departmentRepo;

        public InstructorController(
            IGenericRepository<Instructor> instructorRepo,
            IGenericRepository<Department> departmentRepo)
        {
            _instructorRepo = instructorRepo;
            _departmentRepo = departmentRepo;
        }

        public IActionResult getAll()
        {
            var instructors = _instructorRepo.GetAll();
            return View(instructors);
        }

        public IActionResult getById(int id)
        {
            var instructor = _instructorRepo.GetById(id);
            return View(instructor);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var departments = _departmentRepo.GetAll();
            ViewBag.departments = departments;
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Instructor instructor)
        {
            if (instructor.DeptId != 0)
            {
                if (ModelState.IsValid)
                {
                    _instructorRepo.Add(instructor);
                    _instructorRepo.Save();
                    return RedirectToAction("getAll");
                }
            }
            else
            {
                ModelState.AddModelError("DeptId", "Please select Department");
            }

            var departments = _departmentRepo.GetAll();
            ViewBag.departments = departments;
            return View("Add", instructor);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var instructor = _instructorRepo.GetById(id);
            var departments = _departmentRepo.GetAll();
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
                    _instructorRepo.Update(instructor);
                    _instructorRepo.Save();
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
            var instructor = _instructorRepo.GetById(id);
            if (instructor != null)
            {
                _instructorRepo.Delete(instructor);
                _instructorRepo.Save();
            }
            return RedirectToAction("getAll"); 
        }
    }
}