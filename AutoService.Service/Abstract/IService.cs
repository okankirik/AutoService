using AutoService.Data.Abstract;
using AutoService.Entities;

namespace AutoService.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {
    }
}
