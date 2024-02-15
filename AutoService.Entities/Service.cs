using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoService.Entities;

public class Service : IEntity
{
    public int Id { get; set; }
    [Display(Name = "Servise Geliş Tarihi")]
    public DateTime ServiceArrivalDate { get; set; }
    [Display(Name = "Araç Sorunu"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string CarProblem { get; set; }
    [Display(Name = "Servis Ücreti")]
    public decimal ServicePrice { get; set; }
    [Display(Name = "Servisten Çıkış Tarihi")]
    public DateTime DateOfExitFromService { get; set; }
    [Display(Name = "Yapılan İşlemler")]
    public string? TransactionsMade { get; set; }
    [Display(Name = "Garanti Kapsamında Mı?")]
    public bool IsGuarantee { get; set; }
    [StringLength(15)]
    [Display(Name = "Araç Plakası"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string CarPlate { get; set; }
    [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string Brand { get; set; }
    [StringLength(50)]
    public string? Model { get; set; }
    [StringLength(50)]
    [Display(Name = "Kasa Tipi")]
    public string? BodyType { get; set; }
    [StringLength(50)]
    [Display(Name = "Şase No")]
    public string? ChassisNumber { get; set; }
    [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
    public string Notes { get; set; }
}
