using AutoService.Entities;
using AutoService.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.WebUI.Areas.Admin.Controllers;
[Area("Admin"), Authorize(Policy = "AdminPolicy")]
public class BrandsController : Controller
{
    private readonly IService<Brand> _service;

    public BrandsController(IService<Brand> service)
    {
        _service = service;
    }

    // GET: MarkaController
    public async Task<ActionResult> IndexAsync()
    {
        var model = await _service.GetAllAsync();
        return View(model);
    }

    // GET: MarkaController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: MarkaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: MarkaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(Brand brand)
    {
        try
        {
            await _service.AddAsync(brand);
            await _service.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError("", "Hata Oluştu!");
        }
        return View(brand);
    }

    // GET: MarkaController/Edit/5
    public async Task<ActionResult> EditAsync(int id)
    {
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: MarkaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(int id, Brand brand)
    {
        try
        {
            _service.Update(brand);
            await _service.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError("", "Hata Oluştu!");
        }
        return View(brand);
    }

    // GET: MarkaController/Delete/5
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: MarkaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Brand brand)
    {
        try
        {
            _service.Delete(brand);
            _service.Save();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
