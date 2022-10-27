using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DTO.ProductDtos;
using MyJwtBuild.Web.UI.ApiServices.AuthApi.Interfaces;
using MyJwtBuild.Web.UI.ApiServices.DataApi.Interfaces;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;

namespace MyJwtBuild.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiService _productApiService;
        private readonly IAuthApiService _authApiService;
        public ProductController(IProductApiService productApiService, IAuthApiService authApiService)
        {
            _productApiService = productApiService;
            _authApiService = authApiService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductListDto>? products = await _productApiService.GetAllProductsAsync();
            return View(products);
        }

        public async Task<IActionResult> CreateNewProduct()
        {
            if (!await _authApiService.CheckIsAdminAsync())
                return RedirectToAction("Privacy", "Home");
       
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProduct(Product product)
        {
            if (product != null)
            {
                await _productApiService.CreateProductAsync(product);
                return RedirectToAction("Index");
            }
            return RedirectToAction("CreateProduct");
        }


    }
}
