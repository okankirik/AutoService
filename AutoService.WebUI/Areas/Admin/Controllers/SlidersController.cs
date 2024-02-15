using AutoService.Entities;
using AutoService.Service.Abstract;
using AutoService.WebUI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.WebUI.Areas.Admin.Controllers;
[Area("Admin"), Authorize(Policy = "AdminPolicy")]
public class SlidersController : Controller
{
    private readonly IService<Slider> _service;

    public SlidersController(IService<Slider> service)
    {
        _service = service;
    }


    // GET: SlidersController
    public async Task<ActionResult> Index()
    {
        return View(await _service.GetAllAsync());
    }

    // GET: SlidersController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: SlidersController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: SlidersController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Slider slider, IFormFile? Image)
    {
        try
        {
            slider.Image = await FileHelper.FileLoaderAsync(Image, "/Images/Slider/");
            await _service.AddAsync(slider);
            await _service.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: SlidersController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var data = await _service.FindAsync(id);
        return View(data);
    }

    // POST: SlidersController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, Slider slide, IFormFile? Image)
    {
        try
        {
            if (Image is not null)
                slide.Image = await FileHelper.FileLoaderAsync(Image, "/Images/Slider/");
            _service.Update(slide);
            await _service.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: SlidersController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        var data = await _service.FindAsync(id);
        return View(data);
    }

    // POST: SlidersController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, Slider slider)
    {
        try
        {
            _service.Delete(slider);
            await _service.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
