using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;


        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation]
        public IResult Add(Product product)
        {
            // bir kategoride 10 ürün olabilir 
            var result =Businessrules.Run(CheckCategoryCount(product.CategoryId), CheckNameIfExist(product),CheckCategoryCount());

            if (!result.Success)
            {
                return new ErrorResult();

            }
            
            _productDal.Add(product);
            return new SuccessResult();



        }



        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour== 22)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);
            //}


            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);

            // iş kodları
            //yetkisi varmı

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), "kategoriler seçildi");
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max), "fiyatlara göre listelendi");
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId), "Ürün bulundu");
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetail(), "Detaylar getirildi");
        }
        [ValidationAspect(typeof(Product))]
        public IResult Update(Product product)
        {
            if (CheckCategoryCount(product.CategoryId).Success)
            {
                _productDal.Add(product);
                return new SuccessResult();
            }
            return new ErrorResult();

        }
        public IResult CheckNameIfExist(Product product)
        {
            var result = _productDal.GetAll(p => p.ProductName == product.ProductName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckCategoryCount(int categoryId)
        {
            var productcount = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (productcount >= 10)
            {
                return new ErrorResult();


            }
            return new SuccessResult();
        }
        private IResult CheckCategoryCount()
        {
            if (_categoryService.GetAll().Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceed);
            }
            return new SuccessResult();
        }
    }

}
