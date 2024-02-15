using AutoService.Data;
using AutoService.Data.Concrete;
using AutoService.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Service.Concrete;

public class UserService : UserRepository, IUserService
{
    public UserService(AutoServiceDbContext context) : base(context)
    {
    }
}
