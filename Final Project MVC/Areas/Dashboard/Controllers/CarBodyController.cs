using Business.Concrete;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CarBodyController : Controller
    {
        CarBodyManager _carBodyManager = new();
        public IActionResult Index()
        {
            var data = _carBodyManager.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CarBody carBody)
        {
            var result = _carBodyManager.Add(carBody);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(carBody);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _carBodyManager.GetById(id).Data;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(CarBody carBody)
        {
            var result = _carBodyManager.Update(carBody);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(carBody);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _carBodyManager.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
