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
    public class EfRoleRepository : EfGenericRepository<Role>, IRoleDal
    {
        private readonly MyJwtBuildContext _context;
        public EfRoleRepository(MyJwtBuildContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Role> GetUserRoleByUserIdAsync(int userId)
        {
            User user = await _context.Users.FindAsync(userId);
            Role userRole = await _context.Roles.FirstOrDefaultAsync(x => x.Id == user.RoleId);
            return userRole;
        }
    }
}
