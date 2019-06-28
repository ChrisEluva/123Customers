using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace _123Customers.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        public int AddressId { get; set; }

        public string CustomerPhoneNumber { get; set; }
    }
}