﻿using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class IEfProductDal : IEfEntityRepositoryBase<Product, NorthWindContext> , IProductDal
    {

        //NuGet
       
    }
}
