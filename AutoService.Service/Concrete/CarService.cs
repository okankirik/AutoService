using AutoService.Data;
using AutoService.Data.Concrete;
using AutoService.Service.Abstract;

namespace AutoService.Service.Concrete;

public class CarService : CarRepository, ICarService
{
    public CarService(AutoServiceDbContext context) : base(context)
    {
    }
}
