using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using DU_Community_Commerce_Server_Side.Application_Context;
using DU_Community_Commerce_Server_Side.Models;

namespace DU_Community_Commerce_Server_Side.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly ApplicationContext _applicationContext;

        public ProductRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            var listOfProducts = (from product in _applicationContext.Products
                select product).ToList();
            return listOfProducts;
        }

        public Product GetProductById(string productId)
        {
            var newproduct = (from product in _applicationContext.Products
                where product.ProductId == productId
                select product).FirstOrDefault();
            return newproduct;
        }

        public void InsertProduct(Product product)
        {
            _applicationContext.Products.Add(product);
            Save();
        }

        public void DeleteProduct(string productId)
        {
            Product newproduct = (from product in _applicationContext.Products
                where product.ProductId == productId
                select product).FirstOrDefault();
            _applicationContext.Products.Remove(newproduct);
            Save();
        }

        public void UpdateStudent(Product updateProduct)
        {
            _applicationContext.Products.AddOrUpdate(updateProduct);
            Save();
        }

        public IEnumerable<Product> GetProductsBySubcategory(string subcategory)
        {
            var query = (from product in _applicationContext.Products
                where product.ProductSubcategory == subcategory
                select product).ToList();
            return query;
        }

        public void Save()
        {
            _applicationContext.SaveChanges();
        }


        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _applicationContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}