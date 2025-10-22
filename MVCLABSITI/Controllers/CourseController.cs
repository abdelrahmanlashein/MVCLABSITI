using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Models;
using MVCLABSITI.Repositories;

namespace MVCLABSITI.Controllers
{
    public class CourseController : Controller
    {
        private readonly IGenericRepository<Course> _courseRepo;

        public CourseController(IGenericRepository<Course> courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public IActionResult getAll()
        {
            var courses = _courseRepo.GetAll();
            return View(courses);
        }

        public IActionResult getById(int id)
        {
            var course = _courseRepo.GetById(id);
            return View(course);
        }

        public IActionResult getByName(string name)
        {
            var course = _courseRepo.GetByCondition(c => ((Course)c).Name == name);
            return View(course);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepo.Add(course);
                _courseRepo.Save();
                return RedirectToAction("getAll");
            }
            return View("Add", course);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _courseRepo.GetById(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepo.Update(course);
                _courseRepo.Save();
                return RedirectToAction("getAll");
            }
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = _courseRepo.GetById(id);
            if (course != null)
            {
                _courseRepo.Delete(course);
                _courseRepo.Save();
            }
            return RedirectToAction("getAll");
        }

        public IActionResult UniqueName(string name)
        {
            var course = _courseRepo.GetByCondition(c => ((Course)c).Name == name);
            if (course != null)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }
    }
}