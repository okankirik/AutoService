using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoService.Entities;

public class Customer : IEntity
{
    public int Id { get; set; }
    [StringLength(50), Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string Name { get; set; }
    [StringLength(50), Display(Name = "Soyadı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string Surname { get; set; }
    [StringLength(11), Display(Name = "TC Numarası")]
    public string? IdentityNo { get; set; }
    [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string Email { get; set; }
    [StringLength(500)]
    public string? Address { get; set; }
    [StringLength(15)]
    public string? Phone { get; set; }
    public string? Notes { get; set; }
    [Display(Name = "Araç")]
    public int CarId { get; set; }
    [Display(Name = "Araç")]
    public virtual Car? Car { get; set; }
}
