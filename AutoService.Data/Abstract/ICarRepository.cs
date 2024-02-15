using AutoService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Data.Abstract;

public interface ICarRepository :IRepository<Car>
{
    Task<List<Car>> GetCustomCarList();
    Task<List<Car>> GetCustomCarList(Expression<Func<Car, bool>> expression);
    Task<Car> GetCustomCar(int id);
}
