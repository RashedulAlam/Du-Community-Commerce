using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace DU_Community_Commerce_Server_Side.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductAddress { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSubcategory { get; set; }
        public string ProductLatitude { get; set; }
         public string ProductLongitude { get; set; }
    }
}