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
        public DbSet<ProductTest> ProductsTest { get; set; }
        public DbSet<Person> People { get; set; }
    }
}