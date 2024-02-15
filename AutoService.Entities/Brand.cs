using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoService.Entities;

public class Brand : IEntity
{
    public int Id { get; set; }
    [Display(Name = "Adı")]
    public string Name { get; set; }
}
