﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        // global değişkenleri genelde "_" ile başlatarak isimlendiririz.
        List<Product> _products;

        // constructor metot ctor la yap
        public InMemoryProductDal()
        {
            // ürün oluşturduk.
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId= 1, ProductName="Bardak", UnitPrice=15, UnitsInStock = 15},
                new Product{ProductId=2, CategoryId= 1, ProductName="Kamera", UnitPrice=500, UnitsInStock = 3},
                new Product{ProductId=3, CategoryId= 2, ProductName="Telefon", UnitPrice=1500, UnitsInStock = 2},
                new Product{ProductId=4, CategoryId= 2, ProductName="Klavye", UnitPrice=150, UnitsInStock = 65},
                new Product{ProductId=5, CategoryId= 2, ProductName="Fare", UnitPrice=85, UnitsInStock = 1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /* LINQ kullanmadan delete işlemi 
            Product productToDelete = null;     // silinecek ürünü atayacağımız değişken null koymazsak hata verir

            foreach (var p in _products) //_products u tek tek gezdik
            {
                if (product.ProductId == p.ProductId)   // ürün idlerine göre karşılaştırıp doğru ürünü bulduk
                {
                    productToDelete = p;    // sonra silinecek değişkenimize atadık
                }
            }
            */


            // LINQ - Language Integrated Query  yukarıdaki işlemi yapıyor
            // dolaştıgımız değişkenin id si ürünlerdeki id ye eşit olunca çalışır 

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);   // =>  : lambda işareti
                                                                                                          // p : yukarıdakiyyle aynı dolaşan değişken
            _products.Remove(productToDelete); 
        }

        public List<Product> GetAll()
        {
            // veritabanı oldugu gibi döndürcek
            return _products;
        }


        public void Update(Product product)
        {
            // gönderdiğim ürü id sine eşit olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); 
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }


        public List<Product> GetAllByCategory(int categoryId)  // parametreler camel case
        {   
            // içindeki şarta uyan tüm elemanları liste haline getirir ve döndürür
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
