using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopASP.Models
{
    public class ProductForPartialView
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int QuantityMax { get; set; }
    }
}