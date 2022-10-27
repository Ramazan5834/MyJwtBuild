using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using MyJwtBuild.BUSINESS.Interfaces;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using System.Net.Http.Headers;
using System.Net.Http;
using MyJwtBuild.Data.API.Helpers.CheckUserHelpers;
using AutoMapper;
using MyJwtBuild.DTO.ProductDtos;

namespace MyJwtBuild.Data.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, HttpClient httpClient, IMapper mapper)
        {
            _productService = productService;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44312/api/auth/");
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            List<ProductListDto> productListDtos = _mapper.Map<List<ProductListDto>>(await _productService.GetAllAsync());
            //List<Product> productList = await _productService.GetAllAsync();
            return Ok(productListDtos);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if (!await CheckAdminHelper.CheckIsAdminAsync(_httpClient,Request))
            return BadRequest();

            await _productService.AddAsync(product);
            return Created("", product);
        }



    }
}
