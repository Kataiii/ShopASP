using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopASP.Models
{
    public class ProductForPartialView
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int Quantity { get; set; }
        public int QuantityMax { get; set; }
        public decimal? Price { get; set; }


        public decimal? Sum(int quantity, decimal? price)
        {
            return (quantity*price);
        }

        public decimal? TotalSum(List<ProductForPartialView> products)
        {
            decimal? sum = 0;
            foreach(ProductForPartialView product in products)
            {
                sum += product.Sum(product.Quantity, product.Price);
            }
            return sum;
        }
    }
}