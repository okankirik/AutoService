using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoService.Entities;

public class Sales : IEntity
{
    public int Id { get; set; }
    [Display(Name = "Satış Fiyatı")]
    public decimal SalePrice { get; set; }
    [Display(Name = "Satış Tarihi")]
    public DateTime SaleDate { get; set; }
    [Display(Name = "Araç")]

    public int CarId { get; set; }
    [Display(Name = "Araç")]
    public virtual Car? Car { get; set; }
    [Display(Name = "Müşteri")]
    public int CustomerId { get; set; }
    [Display(Name = "Müşteri")]
    public virtual Customer? Customer { get; set; }
}
