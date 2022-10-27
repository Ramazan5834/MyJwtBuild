using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJwtBuild.DATAACCESS.Interfaces
{
    public interface IProductDal : IGenericDal<Product>
    {
    }
}
