using Microsoft.Extensions.Primitives;
using MyJwtBuild.BUSINESS.Interfaces;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MyJwtBuild.Data.API.Helpers.CheckUserHelpers
{
    public class CheckAdminHelper
    {
        public async static Task<bool> CheckIsAdminAsync(HttpClient httpClient, HttpRequest httpRequest)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44312/api/auth/");
            StringValues systemjwttoken = default;
            httpRequest.Headers.TryGetValue("myaccesstoken", out systemjwttoken);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", systemjwttoken);
            var response = await httpClient.GetAsync("CheckIsAdmin");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
