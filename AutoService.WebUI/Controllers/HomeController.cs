using AutoService.Entities;
using AutoService.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;
using AutoService.Service.Abstract;

namespace AutoService.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Slider> _service;
        private readonly ICarService _carService;

        public HomeController(IService<Slider> service, ICarService carService)
        {
            _service = service;
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel()
            {
                Sliders = await _service.GetAllAsync(),
                Cars = await _carService.GetCustomCarList(a => a.MainPage)
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}