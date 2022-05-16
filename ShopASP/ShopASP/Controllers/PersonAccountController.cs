using ShopASP.Models;
using ShopASP.Models.Context;
using ShopASP.Models.Context.ModelsForDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopASP.Controllers
{
    public class PersonAccountController : Controller
    {
        ShopDB db = new ShopDB();
        // GET: PersonAccount
        public ActionResult Profile()
        {
            return View(Session["user"]);
        }

        public ActionResult Cart(List<ProductForPerson> productForPeople)
        {
            return View(productForPeople);
        }

        [HttpGet]
        public ActionResult AddProductInSession(int id_product, int id_quantity)
        {
            ProductForPerson productForPerson = new ProductForPerson()
            {
                Id = id_product,
                Quantity = 1
            };
            if(Session["array_products"] == null)
            {
                List<ProductForPerson> arrayProducts = new List<ProductForPerson>();
                arrayProducts.Add(productForPerson);
                Session["array_products"] = arrayProducts;
            }
            else
            {
                var arrayProducts = (List<ProductForPerson>)Session["array_products"];
                arrayProducts.Add(productForPerson);
                Session["array_products"] = arrayProducts;
            }
            return PartialView("FormProductForUpdate", new ProductForPartialView()
            {
                Id = id_product,
                Quantity = 1,
                QuantityMax = db.Products.Find(id_product).Quantity
            });
        }

        [HttpGet]
        public ActionResult AddQuantityProductInSession(int id_product, int id_quantity)
        {
            int quantity = id_quantity+1;
            var arrayList = (List<ProductForPerson>)Session["array_products"];
            foreach (ProductForPerson productForPerson in arrayList)
            {
                if (productForPerson.Id == id_product)
                {
                    productForPerson.Quantity = quantity;
                }
            }
            Session["array_products"] = arrayList;
            return PartialView("FormProductForUpdate", new ProductForPartialView()
            {
                Id = id_product,
                Quantity = quantity,
                QuantityMax = db.Products.Find(id_product).Quantity
            });
        }

        public ActionResult ReduceQuantityProductInSession(int id_product, int id_quantity)
        {
            int quantity = id_quantity - 1;
            var arrayList = (List<ProductForPerson>)Session["array_products"];
            foreach (ProductForPerson productForPerson in arrayList)
            {
                if (productForPerson.Id == id_product)
                {
                    productForPerson.Quantity = quantity;
                }
            }
            Session["array_products"] = arrayList;
            return PartialView("FormProductForUpdate", new ProductForPartialView()
            {
                Id = id_product,
                Quantity = quantity,
                QuantityMax = db.Products.Find(id_product).Quantity
            });
        }

        //PartialVIEW
        public ActionResult GetPersonalInformation()
        {
            return PartialView("Personal_information",(Person)Session["user"]);
        }

        public ActionResult GetOrdersInformation()
        {
            return PartialView();
        }

        public ActionResult MakingAnOrder()
        {
            return PartialView();
        }

        public ActionResult ShowAdminPanel()
        {
            return PartialView();
        }
    }
}