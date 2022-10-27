using MyJwtBuild.DTO.UserDtos;

namespace MyJwtBuild.Web.UI.ApiServices.AuthApi.Interfaces
{
    public interface IUserApiService
    {
        Task UserRegisterToSystemAsync(UserRegisterDto userRegisterDto);
    }
}
