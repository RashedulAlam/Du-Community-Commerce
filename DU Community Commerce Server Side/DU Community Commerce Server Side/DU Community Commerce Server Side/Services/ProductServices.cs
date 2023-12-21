using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DU_Community_Commerce_Server_Side.Application_Context;
using DU_Community_Commerce_Server_Side.Repositories;

namespace DU_Community_Commerce_Server_Side.Services
{
    public class ProductServices
    {
        private readonly ProductRepository _productRepository;

        public ProductServices()
        {
            _productRepository = new ProductRepository(new ApplicationContext());
        }
    }
}