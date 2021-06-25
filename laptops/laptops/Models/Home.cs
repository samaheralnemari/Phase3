using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace laptops.Models
{
    public class Home
    {
    }
    public class OrderDetails
    {
        public int CustomerOrderID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string OrderItem { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> OrderPrice { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ProductPrice { get; set; }
        [Required]
        public string CreditNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public string CVV { get; set; }
    }
}