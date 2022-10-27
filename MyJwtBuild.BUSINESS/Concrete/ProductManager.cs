using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyJwtBuild.BUSINESS.Interfaces;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using MyJwtBuild.DATAACCESS.Interfaces;

namespace MyJwtBuild.BUSINESS.Concrete
{
    public class ProductManager:GenericManager<Product>,IProductService
    {
        public ProductManager(IGenericDal<Product> genericDal) : base(genericDal)
        {
        }
    }
}
