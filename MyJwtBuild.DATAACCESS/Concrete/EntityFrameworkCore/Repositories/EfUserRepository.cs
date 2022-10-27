using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Context;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DATAACCESS.Interfaces;

namespace MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUserRepository:EfGenericRepository<User>,IUserDal
    {
        private readonly MyJwtBuildContext _context;
        public EfUserRepository(MyJwtBuildContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserForLoginAsync(User user)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.PasswordHash == user.PasswordHash);
     
        }
    }
}
