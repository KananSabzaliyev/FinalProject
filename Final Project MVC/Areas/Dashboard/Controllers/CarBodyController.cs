using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CarBodyController : Controller
    {
        private readonly ICarbodyService _carbodyService;
        public CarBodyController(ICarbodyService carbodyService)
        {
            _carbodyService = carbodyService;
        }
        public IActionResult Index()
        {
            var data = _carbodyService.GetAll().Data;
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
            var result = _carbodyService.Add(carBody);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(carBody);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _carbodyService.GetById(id).Data;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(CarBody carBody)
        {
            var result = _carbodyService.Update(carBody);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(carBody);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _carbodyService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
