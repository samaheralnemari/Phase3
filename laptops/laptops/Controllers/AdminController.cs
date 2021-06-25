using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using laptops.Models;

namespace laptops.Controllers
{
    public class AdminController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product_View()
        {
            using (LaptopsEntities db = new LaptopsEntities())
            {
                return View(db.Products.ToList());
            }
        }
        public ActionResult Product_Add()
        {
            using (LaptopsEntities db = new LaptopsEntities())
            {
                ViewBag.BrandData =db.Brands.ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Product_Add(ProductDetails productobj)
        {
            using (LaptopsEntities db = new LaptopsEntities())
            {
                var File = productobj.File;
                if (File!=null)
                {
                    File.SaveAs(Server.MapPath("~/Image/" + File.FileName));
                }

                Product obj = new Product()
                {
                    ProductName = productobj.ProductName,
                    ProductImage = File.FileName,
                    BrandID= productobj.BrandID,
                    ProductDescription = productobj.ProductDescription,
                    ProductDiscount = productobj.ProductDiscount,
                    ProductPrice = productobj.ProductPrice,
                };
                db.Products.Add(obj);
                db.SaveChanges();    
            }
            return RedirectToAction("Product_View","Admin");
        }
        [HttpPost]
        public Product Product_Update(Product productobj)
        {
            using (LaptopsEntities db = new LaptopsEntities())
            {
                var Product = db.Products.Where(x=>x.ProductID== productobj.ProductID).FirstOrDefault();
                if (Product != null)
                {
                    Product.BrandID= productobj.BrandID;
                    Product.ProductDescription= productobj.ProductDescription;
                    Product.ProductDiscount= productobj.ProductDiscount;
                    Product.ProductImage= productobj.ProductImage;
                    Product.ProductName = productobj.ProductName;
                    Product.ProductPrice = productobj.ProductPrice;
                }
                db.SaveChanges();
                return Product;
            }       
        }
        //[HttpPost]
        //public Product Product_Search(string product)
        //{
        //    using (LaptopsEntities db = new LaptopsEntities())
        //    {
        //        var Product = db.Products.Where(x => x.ProductID == product.ProductID).FirstOrDefault();

        //    }
        //    return product; 
        //}
    }
}