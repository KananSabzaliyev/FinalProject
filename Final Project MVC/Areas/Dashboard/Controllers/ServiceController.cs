using Business.Abstract;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IServiceservice _serviceService;
        public ServiceController(IServiceservice serviceService)
        {
            _serviceService = serviceService;
        }
        public IActionResult Index()
        {
            var data = _serviceService.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Service service)
        {
            var result = _serviceService.Add(service);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(service);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _serviceService.GetById(id).Data;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Service service)
        {
            var result = _serviceService.Update(service);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(service);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _serviceService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
