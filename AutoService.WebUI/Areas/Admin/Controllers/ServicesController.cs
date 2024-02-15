using AutoService.Entities;
using AutoService.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.WebUI.Areas.Admin.Controllers;
[Area("Admin"), Authorize(Policy = "AdminPolicy")]
public class ServicesController : Controller
{
    private readonly IService<AutoService.Entities.Service> _service;

    public ServicesController(IService<AutoService.Entities.Service> service)
    {
        _service = service;
    }

    // GET: ServislerController
    public async Task<ActionResult> IndexAsync()
    {
        var model = await _service.GetAllAsync();
        return View(model);
    }

    // GET: ServislerController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: ServislerController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ServislerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(AutoService.Entities.Service servis)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _service.AddAsync(servis);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
        }
        return View(servis);
    }

    // GET: ServislerController/Edit/5
    public async Task<ActionResult> EditAsync(int id)
    {
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: ServislerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(int id, AutoService.Entities.Service servis)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _service.Update(servis);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
        }
        return View(servis);
    }

    // GET: ServislerController/Delete/5
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: ServislerController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, AutoService.Entities.Service servis)
    {
        try
        {
            _service.Delete(servis);
            _service.Save();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
