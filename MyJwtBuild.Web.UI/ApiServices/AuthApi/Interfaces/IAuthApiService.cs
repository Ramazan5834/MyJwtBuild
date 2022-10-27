using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;

namespace MyJwtBuild.Web.UI.ApiServices.AuthApi.Interfaces
{
    public interface IAuthApiService
    {
        Task<bool> LoginFromUsSystemAsync(User user);
        Task<bool> CheckIsAdminAsync();
    }
}
