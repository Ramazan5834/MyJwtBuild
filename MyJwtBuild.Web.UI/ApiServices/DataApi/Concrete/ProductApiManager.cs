using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DTO.ProductDtos;
using MyJwtBuild.Web.UI.ApiServices.DataApi.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace MyJwtBuild.Web.UI.ApiServices.DataApi.Concrete
{
    public class ProductApiManager : IProductApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:44327/api/product/");
        }

        public async Task<List<ProductListDto>?> GetAllProductsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("GetAllProducts");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<ProductListDto>>(
                    await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }


        public async Task CreateProductAsync(Product product)
        {
            AddJwtAccessTokenMyHttpClient();
            var jsonData = JsonConvert.SerializeObject(product);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("CreateProduct", content);

        }


        public void AddJwtAccessTokenMyHttpClient()
        {
            var accessToken = _httpContextAccessor.HttpContext.Session.GetString("JWToken");
            _httpClient.DefaultRequestHeaders.Add("myaccesstoken", accessToken);
        }
    }
}
