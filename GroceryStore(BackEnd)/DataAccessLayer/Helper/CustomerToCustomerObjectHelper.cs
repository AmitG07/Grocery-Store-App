using BusinessObjectLayer;
using DataAccessLayer.ModelDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Helper
{
    public class CustomerToCustomerObjectHelper
    {
        public CustomerObject CustomerObjectToCustomerMapping(Customer customer)
        {
            CustomerObject c = new CustomerObject();
            c.CustomerId = customer.CustomerId;
            c.FullName = customer.FullName;
            c.EmailId = customer.EmailId;
            c.PhoneNumber = customer.PhoneNumber;
            c.Password = customer.Password;
            c.Isadmin = c.Isadmin;
            return c;
        }
    }
}
