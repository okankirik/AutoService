using AutoService.Entities;

namespace AutoService.WebUI.Models;

public class CarDetailViewModel
{
    public Car Car { get; set; }
    public Customer? Customer { get; set; }
}
