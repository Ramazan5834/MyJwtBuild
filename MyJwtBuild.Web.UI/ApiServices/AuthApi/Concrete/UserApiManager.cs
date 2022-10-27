using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DTO.UserDtos;
using MyJwtBuild.Web.UI.ApiServices.AuthApi.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace MyJwtBuild.Web.UI.ApiServices.AuthApi.Concrete
{
    public class UserApiManager : IUserApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:44312/api/user/");
        }

        public async Task UserRegisterToSystemAsync(UserRegisterDto userRegisterDto)
        {
            StringContent stringContent =
                new StringContent(JsonConvert.SerializeObject(userRegisterDto), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("UserRegisterToSystem", stringContent);
        }
    }
}
