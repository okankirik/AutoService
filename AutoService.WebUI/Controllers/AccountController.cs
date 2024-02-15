using AutoService.Entities;
using AutoService.Service.Abstract;
using AutoService.WebUI.Areas.Admin.Controllers;
using AutoService.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoService.WebUI.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _service;
    private readonly IService<Role> _RoleService;

    public AccountController(IUserService service, IService<Role> roleService)
    {
        _service = service;
        _RoleService = roleService;
    }

    [Authorize(Policy = "CustomerPolicy")]
    public IActionResult Index()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var guidId = User.FindFirst(ClaimTypes.UserData)?.Value;
        if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(guidId))
        {
            var user = _service.Get(k => k.Email == email && k.UserGuid.ToString() == guidId);
            if (user != null)
            {
                return View(user);
            }
        }
        return NotFound();
    }
    [HttpPost]
    public IActionResult UserUpdate(User user)
    {
        try
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var guidId = User.FindFirst(ClaimTypes.UserData)?.Value;
            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(guidId))
            {
                var person = _service.Get(k => k.Email == email && k.UserGuid.ToString() == guidId);
                if (person != null)
                {
                    person.Name = user.Name;
                    person.Surname = user.Surname;
                    person.Email = user.Email;
                    person.Password = user.Password;
                    person.UserGuid = user.UserGuid;
                    person.UploadDate = user.UploadDate;
                    person.Phone = user.Phone;
                    person.IsActive = user.IsActive;

                    _service.Update(person);
                    _service.Save();
                }
            }
        }
        catch (Exception)
        {
            ModelState.AddModelError("", "Hata Oluştu!");
        }

        
        return RedirectToAction("Index");
    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var role = await _RoleService.GetAsync(r => r.Name == "Müşteri");
                if (role == null)
                {
                    ModelState.AddModelError("", "Kayıt Başarısız!");
                    return View();
                }
                user.RoleId = role.Id;
                user.IsActive = true;
                await _service.AddAsync(user);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
        }
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
    {
        try
        {
            var account = await _service.GetAsync(k => k.Email == loginViewModel.Email && k.Password == loginViewModel.Password && k.IsActive == true);
            if (account == null)
            {
                ModelState.AddModelError("", "Giriş Başarısız!");
            }
            else
            {
                var role = _RoleService.Get(r => r.Id == account.RoleId);

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, account.Name),
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.UserData, account.UserGuid.ToString())

                };
                if (role is not null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                if (role.Name == "Admin")
                {
                    return Redirect("/Admin");
                }
                return Redirect("/Account");
            }

        }
        catch (Exception)
        {
            ModelState.AddModelError("", "Hata oluştu!");
        }
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect("/");
    }
}
