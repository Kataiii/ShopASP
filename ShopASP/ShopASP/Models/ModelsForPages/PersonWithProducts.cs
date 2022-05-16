using ShopASP.Models.Context.ModelsForDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopASP.Models.ModelsForPages
{
    public class PersonWithProducts
    {
        public Person Person { get; set; }
        public List<Product> Products { get; set; }
    }
}