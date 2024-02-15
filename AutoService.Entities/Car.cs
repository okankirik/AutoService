using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoService.Entities;

public class Car : IEntity
{
    public int Id { get; set; }
    [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string Color { get; set; }
    [Display(Name = "Fiyatı")]
    public decimal Price { get; set; }
    [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string Model { get; set; }
    [Display(Name = "Kasa Tipi"), StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string BodyType { get; set; }
    [Display(Name = "Model Yılı")]
    public int ModelYear { get; set; }
    [Display(Name = "Satışta Mı?")]
    public bool IsSale { get; set; }
    [Display(Name = "Anasayfa?")]
    public bool MainPage { get; set; }
    [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string Notes { get; set; }
    [StringLength(100)]
    public string? Image { get; set; }
    [StringLength(100)]
    public string? Image2 { get; set; }
    [StringLength(100)]
    public string? Image3 { get; set; }

    [Display(Name = "Marka Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public int BrandId { get; set; }
    public virtual Brand? Brand { get; set; }
}
