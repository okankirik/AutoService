using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoService.Entities;

public class Role : IEntity
{
    public int Id { get; set; }
    [StringLength(50)]
    [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string Name { get; set; }
}
