using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DU_Community_Commerce_Server_Side.Models;

namespace DU_Community_Commerce_Server_Side.Repositories
{
    interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(string productId);
        void InsertProduct(Product product);
        void DeleteProduct(string productId);
        void UpdateStudent(Product product);
        IEnumerable<Product> GetProductsBySubcategory(string subcategory); 
        void Save();
    }
}
