using AutoService.Entities;
using AutoService.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoService.WebUI.Areas.Admin.Controllers;
[Area("Admin"), Authorize(Policy = "AdminPolicy")]
public class SalesController : Controller
{
    private readonly IService<Sales> _service;
    private readonly IService<Car> _serviceCar;
    private readonly IService<Customer> _serviceCustomer;

    public SalesController(IService<Sales> service, IService<Customer> serviceCustomer, IService<Car> serviceCar)
    {
        _service = service;
        _serviceCustomer = serviceCustomer;
        _serviceCar = serviceCar;
    }

    // GET: SatisController
    public async Task<ActionResult> IndexAsync()
    {
        var model = await _service.GetAllAsync();
        return View(model);
    }

    // GET: SatisController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: SatisController/Create
    public async Task<ActionResult> CreateAsync()
    {
        ViewBag.CarId = new SelectList(await _serviceCar.GetAllAsync(), "Id", "Brand");
        ViewBag.CustomerId = new SelectList(await _serviceCustomer.GetAllAsync(), "Id", "Name");
        return View();
    }

    // POST: SatisController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(Sales sales)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _service.AddAsync(sales);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
        }
        ViewBag.CarId = new SelectList(await _serviceCar.GetAllAsync(), "Id", "Brand");
        ViewBag.CustomerId = new SelectList(await _serviceCustomer.GetAllAsync(), "Id", "Name");
        return View(sales);
    }

    // GET: SatisController/Edit/5
    public async Task<ActionResult> EditAsync(int id)
    {
        ViewBag.CarId = new SelectList(await _serviceCar.GetAllAsync(), "Id", "Brand");
        ViewBag.CustomerId = new SelectList(await _serviceCustomer.GetAllAsync(), "Id", "Name");
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: SatisController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(int id, Sales sales)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _service.Update(sales);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
        }
        ViewBag.CarId = new SelectList(await _serviceCar.GetAllAsync(), "Id", "Brand");
        ViewBag.CustomerId = new SelectList(await _serviceCustomer.GetAllAsync(), "Id", "Name");
        return View(sales);
    }

    // GET: SatisController/Delete/5
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: SatisController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Sales sales)
    {
        try
        {
            _service.Delete(sales);
            _service.Save();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
