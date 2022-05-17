using ShopASP.Models;
using ShopASP.Models.Context;
using ShopASP.Models.Context.ModelsForDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        /*public ActionResult Cart()
        {
            return PartialView();
        }*/


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

        [HttpGet]
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

        [HttpGet]
        public ActionResult ReduceQuantityProductCart(int id_product, int id_quantity)
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
            List<ProductForPartialView> productForPartialViews = new List<ProductForPartialView>();
            foreach (ProductForPerson productForPerson1 in arrayList)
            {
                ProductForPartialView productForPartialView = new ProductForPartialView()
                {
                    Id = productForPerson1.Id,
                    Name = db.Products.Find(productForPerson1.Id).Name,
                    Quantity = productForPerson1.Quantity,
                    QuantityMax = db.Products.Find(productForPerson1.Id).Quantity,
                    Price = db.Products.Find(productForPerson1.Id).Price
                };
                productForPartialViews.Add(productForPartialView);
            }
            return PartialView("Cart", productForPartialViews);
        }

        [HttpGet]
        public ActionResult AddQuantityProductCart(int id_product, int id_quantity)
        {
            int quantity = id_quantity + 1;
            var arrayList = (List<ProductForPerson>)Session["array_products"];
            foreach (ProductForPerson productForPerson in arrayList)
            {
                if (productForPerson.Id == id_product)
                {
                    productForPerson.Quantity = quantity;
                }
            }
            Session["array_products"] = arrayList;
            List<ProductForPartialView> productForPartialViews = new List<ProductForPartialView>();
            foreach(ProductForPerson productForPerson1 in arrayList)
            {
                ProductForPartialView productForPartialView = new ProductForPartialView()
                {
                    Id = productForPerson1.Id,
                    Name = db.Products.Find(productForPerson1.Id).Name,
                    Quantity = productForPerson1.Quantity,
                    QuantityMax = db.Products.Find(productForPerson1.Id).Quantity,
                    Price = db.Products.Find(productForPerson1.Id).Price
                };
                productForPartialViews.Add(productForPartialView);
            }
            return PartialView("Cart",productForPartialViews);
        }

        //PartialVIEW
        [HttpGet]
        public ActionResult GetPersonalInformation()
        {
            return PartialView("Personal_information",(Person)Session["user"]);
        }

        [HttpGet]
        public ActionResult GetOrdersInformation()
        {
            Person person = (Person)Session["user"];
            var orders = db.Orders.Where(x => x.IdPerson == person.Phone).ToList();
            List<ProductForPartialView> products = new List<ProductForPartialView>();
            foreach(Order order in orders)
            {
                ProductForPartialView product = new ProductForPartialView()
                {
                    Id = order.IdProduct,
                    Name = db.Products.Find(order.IdProduct).Name,
                    Price = db.Products.Find(order.IdProduct).Price,
                    Quantity = order.Quantity,
                    QuantityMax = db.Products.Find(order.IdProduct).Quantity
                };
                products.Add(product);
            }
            return PartialView("AllOrdersPerson", products);
        }

        [HttpGet]
        public ActionResult MakingAnOrder()
        {
            var productsList = (List<ProductForPerson>)Session["array_products"];
            List<ProductForPartialView> products = new List<ProductForPartialView>();
            foreach(ProductForPerson productForPerson in productsList)
            {
                ProductForPartialView product = new ProductForPartialView()
                {
                    Id = productForPerson.Id,
                    Quantity = productForPerson.Quantity,
                    Name = db.Products.Find(productForPerson.Id).Name,
                    QuantityMax = db.Products.Find(productForPerson.Id).Quantity,
                    Price = db.Products.Find(productForPerson.Id).Price
                };
                products.Add(product);
            }
            return PartialView("Cart", products);
        }


        public ActionResult ShowAdminPanel()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var productsList = (List<ProductForPerson>)Session["array_products"];
            productsList = productsList.Where(x => x.Id != id).ToList();
            Session["array_products"] = productsList;
            List<ProductForPartialView> productForPartialViews = new List<ProductForPartialView>();
            foreach (ProductForPerson productForPerson1 in productsList)
            {
                ProductForPartialView productForPartialView = new ProductForPartialView()
                {
                    Id = productForPerson1.Id,
                    Name = db.Products.Find(productForPerson1.Id).Name,
                    Quantity = productForPerson1.Quantity,
                    QuantityMax = db.Products.Find(productForPerson1.Id).Quantity,
                    Price = db.Products.Find(productForPerson1.Id).Price
                };
                productForPartialViews.Add(productForPartialView);
            }
            return PartialView("Cart", productForPartialViews);
        }


        [HttpGet]
        public ActionResult AddOrder()
        {
            var productsList = (List<ProductForPerson>)Session["array_products"];
            var products = new List<Product>();

            foreach(ProductForPerson productForPerson in productsList)
            {
                Product product = new Product()
                {
                    Id = productForPerson.Id,
                    Image = db.Products.Find(productForPerson.Id).Image,
                    Name = db.Products.Find(productForPerson.Id).Name,
                    Price = db.Products.Find(productForPerson.Id).Price,
                    Quantity = productForPerson.Quantity
                };
                products.Add(product);
            }

            foreach(Product product1 in products)
            {
                var productDb = db.Products.Find(product1.Id);
                productDb.Quantity -= product1.Quantity;
                db.Entry(productDb).State = EntityState.Modified;
                db.SaveChanges();
                Person person = (Person)Session["user"];
                var order = new Order
                {
                    Id = 1,
                    IdPerson = person.Phone,
                    IdProduct = product1.Id,
                    DateTime = DateTime.Now,
                    Quantity = product1.Quantity
                };
                db.Orders.Add(order);
                db.SaveChanges();
            }
            Session["array_products"] = null;
            return PartialView("Messege");
        }
    }
}