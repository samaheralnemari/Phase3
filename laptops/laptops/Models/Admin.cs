using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace laptops.Models
{
    public class Admin
    {
    }
    public class ProductDetails
    {
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        [Required]
        public int BrandID { get; set; }
        public Nullable<int> ProductPrice { get; set; }
        public Nullable<int> ProductDiscount { get; set; }
        
        public string ProductImage { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}