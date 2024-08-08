using BusinessObjectLayer;
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Helper
{
    public class CustomerObjectToCustomerHelper
    {
        public Customer CustomerObjectToCustomerMapping(CustomerObject customer)
        {
            Customer cust = new Customer();
            cust.CustomerId = customer.CustomerId;
            cust.FullName = customer.FullName;
            cust.EmailId = customer.EmailId;
            cust.PhoneNumber = customer.PhoneNumber;
            cust.Password = customer.Password;
            cust.Isadmin = customer.Isadmin;
            return cust;
        }
    }
}
