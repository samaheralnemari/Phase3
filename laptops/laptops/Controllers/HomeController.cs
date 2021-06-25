using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using laptops.Models;

namespace laptops.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> list = null;

            using (LaptopsEntities db = new LaptopsEntities())
            {
                list = db.Products.ToList();
            }

            //int i = 0;
            //var str= "<div class='row'>"; ;
            //foreach (var item in list)
            //{
            //    if (i % 3 == 0) 
            //    {
            //        str += "</div>";
            //        str += "<div class='row'>";
            //    }
            //    str += @"<div class='card mb-4 box-shadow'>       
            //               <div class='card-body'>
            //                  <p style='display: none;'>"+@item.ProductID+@"</p><img src='~/Image/"+@item.ProductImage+@"' width='200' height='200' alt=''>
            //                  <p>"+@item.ProductName+@"</p>
            //                  <p style='color: red;'>"+@item.ProductPrice+ @" SR</p>
            //                  <input type='submit' value='Add to Cart' class='btn btn-lg btn-block btn-outline-primary'/>
            //                 </div>
            //            </div>";
            //    i++;
            //}
            //ViewBag.ProductData = str;
            return View(list);
        }
        //[HttpPost]
        public ActionResult AddToCart(int? id)
        {
            List<int> Product = new List<int>();
            List<int> Temp = new List<int>();
           
            //TempData["Product"] = Product;

            int x = 0;
            Temp = TempData["Product"] as List<int>;
            if (Temp != null)
            {
                //Product.ForEach(item => Temp.Add(item));
                Temp.Add((int)id);
                TempData["Product"] = Temp;

                x=Convert.ToInt32(TempData["NumberOfProduct"]);
                TempData["NumberOfProduct"] = x + 1;
            }
            else
            {
                Product.Add((int)id);
                TempData["Product"] = Product;
                TempData["NumberOfProduct"] = 1;
            }
            

            return RedirectToAction("Index", "Home");
            //return View();
        }
        public ActionResult CheckOut()
        {
            List<int> Product = new List<int>();
            //List<ProductDetails> ProductDetails = new List<ProductDetails>();
            Product =TempData["Product"] as List<int>;
            string str = "";
            int TotalPrice = 0;

            foreach (int item in Product)
            {
                using (LaptopsEntities db = new LaptopsEntities())
                {
                    var obj = db.Products.Where(x => x.ProductID.Equals(item)).FirstOrDefault();
                    //ProductDetails.Add(new ProductDetails { ProductID = obj.ProductID, ProductName = obj.ProductName, ProductPrice = obj.ProductPrice });
                    str += @"<li class='list-group-item d-flex justify-content-between lh-condensed'>
                            <div>
                                <h6 class='my-0'>"+obj.ProductName+@"</h6>
                            </div>
                            <span class='text-muted'>"+obj.ProductPrice+@"</span>
                        </li>";
                    TotalPrice += (int)obj.ProductPrice;
                }
            }
            ViewBag.ProductData = str;
            ViewBag.TotalPrice = TotalPrice;
            return View();
        }
        [HttpPost]
        public ActionResult CheckOut(OrderDetails Model)
        {
            using (LaptopsEntities db = new LaptopsEntities())
            {
                Order obj = new Order()
                {
                    //OrderItem = Model.OrderItem,
                    OrderDate = DateTime.Now,
                    OrderPrice = Model.OrderPrice, 
                    CreatedDate = DateTime.Now,
                };
                db.Orders.Add(obj);
                db.SaveChanges();

                CustomerOrder_Mapping obj2 = new CustomerOrder_Mapping()
                {
                    OrderID = Model.OrderID,
                    CustomerID = Model.CustomerID,
                    ProductID = Model.ProductID,
                };
                db.CustomerOrder_Mapping.Add(obj2);
                db.SaveChanges();
            }
            return RedirectToAction("Confirmation", "Home");
        }
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}