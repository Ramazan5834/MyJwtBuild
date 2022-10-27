using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyJwtBuild.BUSINESS.Helpers;
using MyJwtBuild.BUSINESS.Interfaces;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DATAACCESS.Interfaces;

namespace MyJwtBuild.BUSINESS.Concrete
{
    public class UserManager : GenericManager<User>, IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IGenericDal<User> genericDal, IUserDal userDal) : base(genericDal)
        {
            _userDal = userDal;
        }

        public async Task<User> GetUserForLoginAsync(User user)
        {
            user.PasswordHash = Md5Helper.MD5Generate(user.PasswordHash);
            return await _userDal.GetUserForLoginAsync(user);
        }

        public async Task RegisterUserToSystemAsync(User user)
        {
            user.PasswordHash = Md5Helper.MD5Generate(user.PasswordHash);
            await _userDal.AddAsync(user);
        }
    }
}
