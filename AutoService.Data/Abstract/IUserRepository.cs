using AutoService.Entities;
using System.Linq.Expressions;

namespace AutoService.Data.Abstract;

public interface IUserRepository : IRepository<User>
{
    Task<List<User>> GetCustomUserList();
    Task<List<User>> GetCustomUserList(Expression<Func<User, bool>> expression);
}
