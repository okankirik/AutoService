using AutoService.Entities;

namespace AutoService.WebUI.Models;

public class HomePageViewModel
{
    public List<Slider> Sliders { get; set; }
    public List<Car> Cars { get; set; }
}
