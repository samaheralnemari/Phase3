using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using laptops.Models;

namespace laptops.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer Model)
        {        
            if (ModelState.IsValid)
            {
                using (LaptopsEntities db = new LaptopsEntities())
                {
                    var check = db.Customers.Where(x => x.CustomerEmail.Equals(Model.CustomerEmail) && x.CustomerPassword.Equals(Model.CustomerPassword)).FirstOrDefault();
                    if (check!=null)
                    {
                        if (check.CustomerStatus != true)
                        {
                            TempData["Name"] = check.CustomerName;
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            return View(Model);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(CustomerDetails Model)
        {
            using (LaptopsEntities db = new LaptopsEntities())
            {
                Customer obj = new Customer()
                {
                    CustomerName = Model.CustomerName,
                    CustomerEmail = Model.CustomerEmail,
                    CustomerStatus = false,
                    CustomerPassword= Model.CustomerPassword,
                    CustomerAddress= Model.CustomerAddress,
                    CreatedDate=DateTime.Now,
                };
                db.Customers.Add(obj);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}