using ShopASP.Models.Context;
using ShopASP.Models.Context.ModelsForDB;
using ShopASP.Models.ModelsForPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopASP.Controllers
{
    public class HomeController : Controller
    {
        ShopDB db = new ShopDB();
        // GET: Home
        public ActionResult MainPage(List<Product> products)
        {
            Person person = (Person)Session["user"];
            ViewBag.PersonName = person.Firstname;
            return View(products);
        }

        [HttpGet]
        public ActionResult Authorization(string notCorrectForm)
        {
            ViewBag.NotCorrect = notCorrectForm;
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult FormProductForAdd(Product product)
        {
            return View(product);
        }

        [HttpPost]
        public ActionResult Authorization(string action,List<string> Strings)
        {
            switch (action)
            {
                case "submit":
                    bool isSessionNew = Session.IsNewSession;
                    Person person = db.People.Find(Request.Form["login"].ToString());
                    if (person == null) return Authorization("Incorrect password or login. Please try again.");
                    if (person.Password != Request.Form["password"].ToString()) 
                        return Authorization("Incorrect password or login. Please try again.");
                    Session["user"] = person;
                    return View("MainPage", db.Products.ToList());
                case "show":
                    return View("MainPage", db.Products.ToList());
                case "add":
                    _ = Session.IsNewSession;
                    Person personadd = new Person()
                    {
                        Phone = Request.Form["login"],
                        Surname = Request.Form["surname"],
                        Firstname = Request.Form["firstname"],
                        Patronymic = Request.Form["patronymic"],
                        Email = Request.Form["email"],
                        Password = Request.Form["password"],
                        IsAdmin = false
                    };
                    db.People.Add(personadd);
                    db.SaveChanges();
                    Session["user"] = personadd;
                    return View("MainPage", db.Products.ToList());
                case "log_in":
                    return Authorization("");
                case "authorisation":
                    return Authorization("I'm sorry, but you have to log in to order");
            }
            return Authorization("");
        }

        public Person GetPersonFromSession()
        {
            var person = Session["user"];
            return (Person)person;
        }
    }
}