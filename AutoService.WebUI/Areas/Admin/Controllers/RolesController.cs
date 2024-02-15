using AutoService.Entities;
using AutoService.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.WebUI.Areas.Admin.Controllers;
[Area("Admin"), Authorize(Policy = "AdminPolicy")]
public class RolesController : Controller
{
    private readonly IService<Role> _service;

    public RolesController(IService<Role> service)
    {
        _service = service;
    }

    // GET: RollerController
    public async Task<ActionResult> IndexAsync()
    {
        var model = await _service.GetAllAsync();
        return View(model);
    }

    // GET: RollerController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: RollerController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: RollerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Role role)
    {
        try
        {
            _service.Add(role);
            _service.Save();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: RollerController/Edit/5
    public async Task<ActionResult> EditAsync(int id)
    {
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: RollerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Role role)
    {
        try
        {
            _service.Update(role);
            _service.Save();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: RollerController/Delete/5
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var model = await _service.FindAsync(id);
        return View(model);
    }

    // POST: RollerController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Role role)
    {
        try
        {
            _service.Delete(role);
            _service.Save();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
