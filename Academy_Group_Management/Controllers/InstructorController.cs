using Academy_Group_Management.Models.Entities;
using Academy_Group_Management.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Academy_Group_Management.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _repo;
        public InstructorController(IInstructorRepository repo)
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
            return View();
        }

        [HttpPost]

        public IActionResult Create(Instructor instructor) 
        {
            _repo.Create(instructor);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        { 
           var data =  _repo.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        { 
            _repo.Update(instructor);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var data = _repo.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Instructor instructor)
        {
            _repo.Delete(instructor);
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            var data = _repo.GetById(id);
            return View(data);
        }




    }
}
