using AutoService.Entities;
using AutoService.Service.Abstract;
using AutoService.WebUI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoService.WebUI.Areas.Admin.Controllers;
[Area("Admin"), Authorize(Policy = "AdminPolicy")]
public class CarsController : Controller
{
    private readonly ICarService _service;
    private readonly IService<Brand> _serviceBrand;

    public CarsController(ICarService service, IService<Brand> serviceBrand)
    {
        _service = service;
        _serviceBrand = serviceBrand;
    }

    // GET: AraclarController
    public async Task<ActionResult> IndexAsync()
    {
        var model = await _service.GetCustomCarList();
        return View(model);
    }

    // GET: AraclarController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: AraclarController/Create
    public async Task<ActionResult> CreateAsync()
    {
        ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
        return View();
    }

    // POST: AraclarController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(Car car, IFormFile? Image, IFormFile? Image2, IFormFile? Image3)
    {
        if (ModelState.IsValid)
        {
            try
            {
                car.Image = await FileHelper.FileLoaderAsync(Image, "/Images/Cars/");
                car.Image2 = await FileHelper.FileLoaderAsync(Image2, "/Images/Cars/");
                car.Image3 = await FileHelper.FileLoaderAsync(Image3, "/Images/Cars/");
                await _service.AddAsync(car);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata oluştu!");
            }
        }
        ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
        return View(car);
    }

    // GET: AraclarController/Edit/5
    public async Task<ActionResult> EditAsync(int id)
    {
        ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: AraclarController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(int id, Car car,  IFormFile? Image, IFormFile? Image2, IFormFile? Image3)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (Image is not null)
                {
                    car.Image = await FileHelper.FileLoaderAsync(Image, "/Images/Cars/");
                }
                if (Image2 is not null)
                {
                    car.Image2 = await FileHelper.FileLoaderAsync(Image2, "/Images/Cars/");
                }
                if (Image3 is not null)
                {
                    car.Image3 = await FileHelper.FileLoaderAsync(Image3, "/Images/Cars/");
                }
                _service.Update(car);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata oluştu!");
            }
        }
        ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
        return View(car);
    }

    // GET: AraclarController/Delete/5
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: AraclarController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteAsync(int id, Car car)
    {
        try
        {
            _service.Delete(car);
            await _service.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
