using AutoService.Data.Abstract;
using AutoService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutoService.Data.Concrete;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AutoServiceDbContext context) : base(context)
    {
    }

    public async Task<List<User>> GetCustomUserList()
    {
        return await _dbSet.AsNoTracking().Include(x => x.Role).ToListAsync();
    }

    public async Task<List<User>> GetCustomUserList(Expression<Func<User, bool>> expression)
    {
        return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Role).ToListAsync();
    }
}
