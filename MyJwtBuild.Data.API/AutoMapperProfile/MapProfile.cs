using AutoMapper;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DTO.ProductDtos;

namespace MyJwtBuild.Data.API.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();

        }
    }
}
