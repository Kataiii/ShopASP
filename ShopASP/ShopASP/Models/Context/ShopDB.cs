using ShopASP.Models.Context.ModelsForDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopASP.Models.Context
{
    public class ShopDB:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Order> Orders { get; set; }

        public System.Data.Entity.DbSet<ShopASP.Models.ProductForPerson> ProductForPersons { get; set; }
    }
}