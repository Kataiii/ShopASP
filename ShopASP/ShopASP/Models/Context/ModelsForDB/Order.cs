using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopASP.Models.Context.ModelsForDB
{
    public class Order
    {
        public int Id { get; set; }
        public string IdPerson { get; set;  }
        public int IdProduct { get; set; }
        public DateTime DateTime { get; set; }
        public int Quantity { get; set; }
    }
}