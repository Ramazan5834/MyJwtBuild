using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Context;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DATAACCESS.Interfaces;

namespace MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Repositories
{
    public class EfProductRepository:EfGenericRepository<Product>,IProductDal
    {
        public EfProductRepository(MyJwtBuildContext context) : base(context)
        {
        }
    }
}
