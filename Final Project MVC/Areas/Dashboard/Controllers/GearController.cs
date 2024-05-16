using Business.Concrete;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class GearController : Controller
    {
        GearManager _gearManager = new();
        public IActionResult Index()
        {
            var data = _gearManager.GetAll().Data;
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
            var result = _gearManager.Add(gear);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(gear);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _gearManager.GetById(id).Data;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Gear gear)
        {
            var result = _gearManager.Update(gear);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(gear);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _gearManager.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
