using System.ComponentModel.DataAnnotations;

namespace AutoService.WebUI.Models;

public class LoginViewModel
{
    [StringLength(50), Required(ErrorMessage ="{0} Boş Bırakılamaz!")]
    public string Email { get; set; }
    [Display(Name ="Şifre"), StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string Password { get; set; }
}
