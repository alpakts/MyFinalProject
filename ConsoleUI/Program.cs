using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager Cmanager = new CategoryManager(new EfCategoryDal());
            foreach (var category in Cmanager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            //open closed principle
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            if (productManager.GetProductDetail().Success==true)
            {
                foreach (var product in productManager.GetProductDetail().Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(productManager.GetProductDetail().Message);
            }
            
        }
    }
}
