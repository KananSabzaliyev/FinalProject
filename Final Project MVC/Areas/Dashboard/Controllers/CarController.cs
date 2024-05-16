using Business.Concrete;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_MVC.Area.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CarController : Controller
    {
        CarManager _carManager = new CarManager();
        BrandManager _brandManager = new BrandManager();
        CarBodyManager _carBodyManager = new CarBodyManager();
        GearManager _gearManager = new GearManager();
        public IActionResult Index()
        {
            var data = _carManager.GetAllWithDetails().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Brands"] = _brandManager.GetAll().Data;
            ViewData["Gears"] = _gearManager.GetAll().Data;
            ViewData["CarBodies"] = _carBodyManager.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            var result = _carManager.Add(car);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(car);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Brands"] = _brandManager.GetAll().Data;

            ViewData["Gears"] = _gearManager.GetAll().Data;

            ViewData["CarBodies"] = _carBodyManager.GetAll().Data;
            var result = _carManager.GetById(id).Data;
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            var result = _carManager.Update(car);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(car);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _carManager.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
