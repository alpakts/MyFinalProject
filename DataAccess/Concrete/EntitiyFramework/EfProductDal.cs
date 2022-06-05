using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfProductDal : IEfEntityRepositoryBase<Product, NorthWindContext>, IProductDal
    {

        //NuGet
        public List<ProductDetailDto> GetProductDetail()
        {
            using (NorthWindContext context=new NorthWindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 CategoryName = c.CategoryName,
                                 ProductName = p.ProductName,
                                 UnitPrice = p.UnitPrice,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();

            }
        }
    }
}
