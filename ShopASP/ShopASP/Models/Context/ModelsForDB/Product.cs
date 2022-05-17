using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopASP.Models.Context.ModelsForDB
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }

        public bool Ckeck(Product product, Object productForPeople)
        {
            List<ProductForPerson> products = (List<ProductForPerson>)productForPeople;
            for(int i=0; i< products.Count; i++)
            {
                if (product.Id == products[i].Id) return true;
            }
            return false;
        }
    }
}