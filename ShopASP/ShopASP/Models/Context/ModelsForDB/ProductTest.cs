using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopASP.Models.Context.ModelsForDB
{
    public class ProductTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}