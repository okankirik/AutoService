using AutoService.Entities;
using AutoService.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoService.WebUI.Areas.Admin.Controllers;
[Area("Admin"), Authorize(Policy = "AdminPolicy")]
public class CustomersController : Controller
{
    private readonly IService<Customer> _service;
    private readonly IService<Car> _carService;

    public CustomersController(IService<Customer> service, IService<Car> serviceCar)
    {
        _service = service;
        _carService = serviceCar;
    }

    // GET: MusterilerController
    public async Task<ActionResult> IndexAsync()
    {
        var model = await _service.GetAllAsync();
        return View(model);
    }

    // GET: MusterilerController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: MusterilerController/Create
    public async Task<ActionResult> CreateAsync()
    {
        ViewBag.CarId = new SelectList(await _carService.GetAllAsync(), "Id", "Model");
        return View();
    }

    // POST: MusterilerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(Customer customer)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _service.AddAsync(customer);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
        }
        ViewBag.CarId = new SelectList(await _carService.GetAllAsync(), "Id", "Model");
        return View(customer);
    }

    // GET: MusterilerController/Edit/5
    public async Task<ActionResult> EditAsync(int id)
    {
        ViewBag.CarId = new SelectList(await _carService.GetAllAsync(), "Id", "Model");
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: MusterilerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(int id, Customer customer)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _service.Update(customer);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
        }
        ViewBag.CarId = new SelectList(await _carService.GetAllAsync(), "Id", "Model");
        return View(customer);
    }

    // GET: MusterilerController/Delete/5
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: MusterilerController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Customer customer)
    {
        try
        {
            _service.Delete(customer);
            _service.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
