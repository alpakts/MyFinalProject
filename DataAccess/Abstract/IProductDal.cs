using Core.DataAccess;
using Core.EntityFramework;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // code refactoring
    public interface IProductDal :  IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetail();
    }
}
