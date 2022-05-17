using ShopASP.Models.Context.ModelsForDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopASP.Models.ModelForPartialView
{
    public class ShopDBMain
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Order> Orders { get; set; }
        public IQueryable<Customer_with_orders> customer_With_Orders { get; set; }
    }
}