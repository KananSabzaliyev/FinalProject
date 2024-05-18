using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_MVC.Area.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarbodyService _carbodyService;
        private readonly IBrandservice _brandService;
        private readonly IGearservice _gearService;
        public CarController(ICarService carService,IBrandservice brandService,ICarbodyService carbodyService,IGearservice gearService)
        {
            _carService = carService;
            _carbodyService = carbodyService;
            _brandService = brandService;
            _gearService = gearService;
        }
        public IActionResult Index()
        {
            var data = _carService.GetAllWithDetails().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Brands"] = _brandService.GetAll().Data;
            ViewData["Gears"] = _gearService.GetAll().Data;
            ViewData["CarBodies"] = _carbodyService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            var result = _carService.Add(car);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(car);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Brands"] = _brandService.GetAll().Data;

            ViewData["Gears"] = _gearService.GetAll().Data;

            ViewData["CarBodies"] = _carbodyService.GetAll().Data;
            var result = _carService.GetById(id).Data;
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            var result = _carService.Update(car);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(car);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _carService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
