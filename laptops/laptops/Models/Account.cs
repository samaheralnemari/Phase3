using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laptops.Models
{
    public class Account
    {

    }
    public class CustomerDetails
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public Nullable<bool> CustomerStatus { get; set; }
        public string CustomerPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string CustomerAddress { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}