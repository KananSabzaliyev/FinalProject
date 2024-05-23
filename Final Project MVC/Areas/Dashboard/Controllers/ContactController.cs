using Business.Abstract;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            var data = _contactService.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            var result = _contactService.Add(contact);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _contactService.GetById(id).Data;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var result = _contactService.Update(contact);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _contactService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
