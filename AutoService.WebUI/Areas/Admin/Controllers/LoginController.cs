﻿using AutoService.Entities;
using AutoService.Service.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoService.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class LoginController : Controller
{
    private readonly IService<User> _service;
    private readonly IService<Role> _serviceRole;

    public LoginController(IService<User> service, IService<Role> serviceRole)
    {
        _service = service;
        _serviceRole = serviceRole;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> IndexAsync(string email, string password)
    {
        try
        {
            var account = _service.Get(k => k.Email == email && k.Password == password && k.IsActive == true);
            if (account == null)
            {
                TempData["Mesaj"] = "Giriş Başarısız!";
            }
            else
            {
                var role = _serviceRole.Get(r => r.Id == account.RoleId);

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, account.Name)

                };
                if (role is not null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return Redirect("/Admin");
            }

        }
        catch (Exception)
        {

            TempData["Mesaj"] = "Hata Oluştu!";
        }
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect("/Admin/Login");
    }
}
