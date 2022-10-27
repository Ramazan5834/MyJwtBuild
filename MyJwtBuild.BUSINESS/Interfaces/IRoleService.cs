using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;

namespace MyJwtBuild.BUSINESS.Interfaces
{
    public interface IRoleService:IGenericService<Role>
    {
        Task<Role> GetUserRoleByUserIdAsync(int userId);
    }
}
