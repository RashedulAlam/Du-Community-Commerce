using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using DU_Community_Commerce_Server_Side.Application_Context;
using DU_Community_Commerce_Server_Side.Models;

namespace DU_Community_Commerce_Server_Side.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ProductImageRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }


        public ProductImage GetProductImageOne(string productId)
        {
            var query = (from image in _applicationContext.ProductImages
                where image.ProductId == productId
                select image).FirstOrDefault();
            return query;
        }

        public IEnumerable<ProductImage> GetAllProductImages(string productId)
        {
            var query = (from image in _applicationContext.ProductImages
                where image.ProductId == productId
                select image).ToList();
            return query;
        }

        public void InsertImage(ProductImage productImage)
        {
            _applicationContext.ProductImages.Add(productImage);
            Save();
        }

        public void UpdateImage(ProductImage productImage)
        {
            _applicationContext.ProductImages.AddOrUpdate(productImage);
        }

        public void DeleteImages(string productId)
        {
            var query = (from image in _applicationContext.ProductImages
                         where image.ProductId == productId
                         select image).ToList();
            _applicationContext.ProductImages.RemoveRange(query);
            Save();
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