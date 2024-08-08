using BusinessObjectLayer;
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Helper
{
    public class CustomerLoginToCustomerObjectHelper
    {
        public CustomerObject CustomerLoginToCustomerObjectMapping(CustomerLogin customer)
        {
            CustomerObject cust = new CustomerObject();
            cust.EmailId = customer.EmailId;
            cust.Password = customer.Password;
            return cust;
        }
    }
}
