using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Final_Project_MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class BrandController : Controller
    {
        private readonly IBrandservice _brandService;
        public BrandController(IBrandservice brandService)
        {
            _brandService = brandService;
        }
        public IActionResult Index()
        {
            var data = _brandService.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _brandService.GetById(id).Data;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _brandService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
