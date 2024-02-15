using AutoService.Entities;
using AutoService.Service.Abstract;
using AutoService.Service.Concrete;
using AutoService.WebUI.Models;
using AutoService.WebUI.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoService.WebUI.Controllers;

public class CarController : Controller
{
    private readonly ICarService _carService;
    private readonly IService<Customer> _customerService;
    private readonly IUserService _userService;

    public CarController(ICarService carService, IService<Customer> customerService, IUserService userService)
    {
        _carService = carService;
        _customerService = customerService;
        _userService = userService;
    }

    public async Task<IActionResult> Index(int? id)
    {
        if (id == null)
            return BadRequest();


        var car = await _carService.GetCustomCar(id.Value);
        if (car == null)
            return NotFound();

        var model = new CarDetailViewModel();
        model.Car = car;

        if (User.Identity.IsAuthenticated)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var guidId = User.FindFirst(ClaimTypes.UserData)?.Value;
            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(guidId))
            {
                var person = _userService.Get(k => k.Email == email && k.UserGuid.ToString() == guidId);
                if (person != null)
                {
                    model.Customer = new Customer
                    {
                        Name = person.Name,
                        Surname = person.Surname,
                        Email = person.Email,
                        Phone = person.Phone
                    };
                }
            }
        }



        return View(model);
    }
    [Route("tum-araclarimiz")]
    public async Task<IActionResult> CarList()
    {
        var model = await _carService.GetCustomCarList(c => c.IsSale);
        return View(model);
    }

    public async Task<IActionResult> Search(string search)
    {
        var model = await _carService.GetCustomCarList(c => c.IsSale && c.Brand.Name.Contains(search) || c.BodyType.Contains(search) || c.Model.Contains(search));
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> CustomerRegistration(Customer customer)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _customerService.AddAsync(customer);
                await _customerService.SaveAsync();
                //Gerçek mail adresi yazılmadığından yorum satırına alındı.
                //await MailHelper.SendMailAsync(customer);
                TempData["Message"] = "<div class='alert alert-success'>Talebiniz alınmıştır. Teşekkürler..</div>";
                return Redirect("/Car/Index/" + customer.CarId);
            }
            catch
            {
                TempData["Message"] = "<div class='alert alert-danger'>Bir hata oluştu!</div>";
                ModelState.AddModelError("", "Hata Oluştu!");
            }
        }
        return View();
    }
}
