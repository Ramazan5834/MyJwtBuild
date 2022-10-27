using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyJwtBuild.BUSINESS.Interfaces;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DATAACCESS.Interfaces;

namespace MyJwtBuild.BUSINESS.Concrete
{
    public class RoleManager:GenericManager<Role>,IRoleService
    {
        private readonly IRoleDal _roleDal;
        public RoleManager(IGenericDal<Role> genericDal, IRoleDal roleDal) : base(genericDal)
        {
            _roleDal = roleDal;
        }

        public async Task<Role> GetUserRoleByUserIdAsync(int userId)
        {
            return await _roleDal.GetUserRoleByUserIdAsync(userId);
        }
    }
}
