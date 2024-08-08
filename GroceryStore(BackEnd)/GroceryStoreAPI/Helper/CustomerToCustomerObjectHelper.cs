using BusinessObjectLayer;
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Helper
{
    public class CustomerToCustomerObjectHelper
    {
        public CustomerObject CustomerToCustomerObjectMapping(Customer customer)
        {
            CustomerObject cust = new CustomerObject();
            cust.FullName = customer.FullName;
            cust.PhoneNumber = customer.PhoneNumber;
            cust.EmailId = customer.EmailId;
            cust.Password = customer.Password;
            return cust;
        }
    }
}
