using BusinessObjectLayer;
using DataAccessLayer.ModelDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Helper
{
    public class CustomerObjectToCustomerHelper
    {
        public Customer CustomerObjectToCustomerMapping(CustomerObject customer)
        {
            Customer c = new Customer();
            c.FullName = customer.FullName;
            c.EmailId = customer.EmailId;
            c.PhoneNumber = customer.PhoneNumber;
            c.Password = customer.Password;
            return c;
        }
    }
}
