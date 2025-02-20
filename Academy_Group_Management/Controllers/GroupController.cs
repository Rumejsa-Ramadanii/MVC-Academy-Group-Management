using Academy_Group_Management.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Academy_Group_Management.Models.Entities;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Academy_Group_Management.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupRepository _repo;
        public GroupController(IGroupRepository repo)
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
            var instructors = _repo.GetInstructors();
            ViewBag.Instructors = new SelectList(instructors, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Entities.Group group)
        {
            _repo.Create(group);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) 
        {
            var data = _repo.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Models.Entities.Group group) 
        {
            _repo.Update(group);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = _repo.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Models.Entities.Group group)
        {
            _repo.Delete(group);
            return RedirectToAction("Index");

        }
       
        public IActionResult Details(int id)
        {
            var data = _repo.GetById(id);
            return View(data);
        }



    }
}
