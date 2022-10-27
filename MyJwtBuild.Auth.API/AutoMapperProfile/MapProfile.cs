using AutoMapper;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DTO.ProductDtos;
using MyJwtBuild.DTO.UserDtos;

namespace MyJwtBuild.Auth.API.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserRegisterDto, User>().ReverseMap();

        }
    }
}
