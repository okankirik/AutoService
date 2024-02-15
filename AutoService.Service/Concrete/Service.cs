using AutoService.Data;
using AutoService.Data.Concrete;
using AutoService.Entities;
using AutoService.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Service.Concrete;

public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
{
    public Service(AutoServiceDbContext context) : base(context)
    {
    }
}
