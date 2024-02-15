using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoService.Entities;

public class User : IEntity
{
    public int Id { get; set; }
    [StringLength(50)]
    [Display(Name = "Adı")]
    public string Name { get; set; }
    [StringLength(50)]
    [Display(Name = "Soyadı")]
    public string Surname { get; set; }
    [StringLength(50)]
    public string Email { get; set; }
    [StringLength(20)]
    public string Phone { get; set; }
    [StringLength(50)]
    [Display(Name = "Kullanıcı Adı")]
    public string UserName { get; set; }
    [StringLength(50)]
    public string Password { get; set; }
    public bool IsActive { get; set; }
    [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
    //ScaffoldColumn(false) = Ekranda bu kolon için gerekli alanları oluşturmaz.
    public DateTime? UploadDate { get; set; } = DateTime.Now;
    public int RoleId { get; set; }
    public virtual Role? Role { get; set; }
    public Guid? UserGuid { get; set; } = Guid.NewGuid();
}
