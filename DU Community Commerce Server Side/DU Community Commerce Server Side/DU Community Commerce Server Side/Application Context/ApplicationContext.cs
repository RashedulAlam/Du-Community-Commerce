using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DU_Community_Commerce_Server_Side.Models;

namespace DU_Community_Commerce_Server_Side.Application_Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SearchItem> SearchItems { get; set; } 

    }
}