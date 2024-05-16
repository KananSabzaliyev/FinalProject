using Business.Concrete;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Final_Project_MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class BrandController : Controller
    {
        BrandManager brandManager = new();
        public IActionResult Index()
        {
            var data = brandManager.GetAll().Data;
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
            var result = brandManager.Add(brand);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = brandManager.GetById(id).Data;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            var result = brandManager.Update(brand);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = brandManager.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
