using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DU_Community_Commerce_Server_Side.Models
{
    public class ProductImage
    {
        [Key]
        public string ImageName { get; set; }
        public string ProductId { get; set; }
    }
}