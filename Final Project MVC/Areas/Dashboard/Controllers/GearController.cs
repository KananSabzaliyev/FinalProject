using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class GearController : Controller
    {
        private readonly IGearservice _gearService;
        public GearController(IGearservice gearService)
        {
            _gearService = gearService;
        }
        public IActionResult Index()
        {
            var data = _gearService.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Gear gear)
        {
            var result = _gearService.Add(gear);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(gear);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _gearService.GetById(id).Data;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Gear gear)
        {
            var result = _gearService.Update(gear);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(gear);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _gearService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
