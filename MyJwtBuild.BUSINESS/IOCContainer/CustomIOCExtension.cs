using Microsoft.Extensions.DependencyInjection;
using MyJwtBuild.BUSINESS.Concrete;
using MyJwtBuild.BUSINESS.Interfaces;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Context;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Repositories;
using MyJwtBuild.DATAACCESS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJwtBuild.BUSINESS.IOCContainer
{
    public static class CustomIOCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<MyJwtBuildContext>();

            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IRoleDal, EfRoleRepository>();
            services.AddScoped<IRoleService, RoleManager>();

            services.AddScoped<IUserDal, EfUserRepository>();
            services.AddScoped<IUserService, UserManager>();

        }

    }

  
}
