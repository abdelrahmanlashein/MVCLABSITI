using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Filters;
using MVCLABSITI.Models;
using MVCLABSITI.Repositories;

namespace MVCLABSITI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IGenericRepository<Department> _departmentRepo;

        public DepartmentController(IGenericRepository<Department> departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public IActionResult getAll()
        {
            var departments = _departmentRepo.GetAll();
            return View(departments);
        }

        public IActionResult getById(int id)
        {
            var department = _departmentRepo.GetById(id);
            return View(department);
        }

        public IActionResult getByName(string name)
        {
            var department = _departmentRepo.GetAll().FirstOrDefault(d => d.Name == name);
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
                _departmentRepo.Add(department);
                _departmentRepo.Save();
                return RedirectToAction("getAll");
            }
            return View("Add", department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _departmentRepo.GetById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepo.Update(department);
                _departmentRepo.Save();
                return RedirectToAction("getAll");
            }
            return View(department);
        }

        public IActionResult Delete(int id)
        {
            var department = _departmentRepo.GetById(id);
            _departmentRepo.Delete(department);
            _departmentRepo.Save();
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
                _departmentRepo.Add(department);
                _departmentRepo.Save();
                return RedirectToAction("getAll");
            }
            return View(department);
        }
    }
}