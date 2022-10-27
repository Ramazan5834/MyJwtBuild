using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.Web.UI.ApiServices.AuthApi.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MyJwtBuild.Web.UI.ApiServices.AuthApi.Concrete
{
    public class AuthApiManager : IAuthApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:44312/api/auth/");
        }

        public async Task<bool> CheckIsAdminAsync()
        {
            var accessToken = _httpContextAccessor.HttpContext.Session.GetString("JWToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.GetAsync("CheckIsAdmin");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> LoginFromUsSystemAsync(User user)
        {
            StringContent stringContent =
                  new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("LoginFromUsSystem", stringContent);
            if (response.IsSuccessStatusCode)
            {
                string token = await response.Content.ReadAsStringAsync();
                _httpContextAccessor.HttpContext.Session.SetString("JWToken", token);
                return true;
            }
            return false;


        }
    }
}
