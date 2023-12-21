using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DU_Community_Commerce_Server_Side.Models;

namespace DU_Community_Commerce_Server_Side.Repositories
{
    interface IProductImageRepository
    {
        ProductImage GetProductImageOne(string productId);
        IEnumerable<ProductImage> GetAllProductImages(string productId);

        void InsertImage(ProductImage productImage);
        void UpdateImage(ProductImage productImage);
        void DeleteImages(string productId);
        void Save();


    }
}
