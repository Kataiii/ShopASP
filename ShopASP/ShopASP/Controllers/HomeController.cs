using ShopASP.Models.Context;
using ShopASP.Models.Context.ModelsForDB;
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
        public ActionResult MainPage()
        {
            //var products = db.ProductsTest.ToList();
            return View();
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

        [HttpPost]
        public ActionResult Authorization(string action,List<string> Strings)
        {
            switch (action)
            {
                case "submit":
                    Person person = db.People.Find(Request.Form["login"].ToString());
                    if (person == null) return Authorization("Incorrect password or login. Please try again.");
                    if (person.Password != Request.Form["password"].ToString()) 
                        return Authorization("Incorrect password or login. Please try again.");
                    return View("MainPage");
                case "show":
                    return Authorization("");
                case "add":
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
                    return View("MainPage");
            }
            return Authorization("");
        }
    }
}