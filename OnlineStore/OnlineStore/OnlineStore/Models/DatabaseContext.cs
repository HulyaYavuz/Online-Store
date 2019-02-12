using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Bank> Banks { get; private set; }

        public DbSet<Role> Roles { get; private set; }

        public DbSet<Image> Images { get; private set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Instalment> Instalments { get; set; }

        public DbSet<Stock> Stocks { get; set; }

    }
}