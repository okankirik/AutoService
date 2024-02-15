using AutoService.Data.Abstract;
using AutoService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Data.Concrete;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(AutoServiceDbContext context) : base(context)
    {
    }

    public async Task<Car> GetCustomCar(int id)
    {
        return await _dbSet.AsNoTracking().Include(x => x.Brand).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Car>> GetCustomCarList()
    {
        return await _dbSet.AsNoTracking().Include(x => x.Brand).ToListAsync();
    }

    public async Task<List<Car>> GetCustomCarList(Expression<Func<Car, bool>> expression)
    {
        return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Brand).ToListAsync();
    }
}
