using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DTO.ProductDtos;

namespace MyJwtBuild.Web.UI.ApiServices.DataApi.Interfaces
{
    public interface IProductApiService
    {
        Task<List<ProductListDto>?> GetAllProductsAsync();
        Task CreateProductAsync(Product product);
    }
}
