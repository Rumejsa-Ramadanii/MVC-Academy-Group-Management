using Academy_Group_Management.Models.Entities;
using Academy_Group_Management.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Academy_Group_Management.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;
        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var data = _repo.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            var groups = _repo.GetGroups();
            ViewBag.Groups = new SelectList(groups, "Id", "Name");
            var instructors = _repo.GetInstructors();
            ViewBag.Instructors = new SelectList(instructors, "Id", "Name");
            return View();
        }
        [HttpPost]

        public IActionResult Create(Student student)
        {
            _repo.Create(student);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id) 
        { 
           var data = _repo.GetById(id);
            return View(data);

        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _repo.Update(student);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var data = _repo.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _repo.Delete(student);
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            var data = _repo.GetById(id);
            return View(data);
        }


    }
}
