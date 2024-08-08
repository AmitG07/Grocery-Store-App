using BusinessLayer.Interfaces;
using BusinessObjectLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class CustomerBL : ICustomerBL
    {
        private readonly ICustomerDAL _customerDAL;

        public CustomerBL(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        public bool AddCustomer(CustomerObject customer)
        {
            if (_customerDAL.AddCustomer(customer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomerObject IsValid(CustomerObject customer)
        {
            CustomerObject cust = _customerDAL.IsValid(customer);
            if (cust != null)
            {
                return cust;
            }
            return null;
        }
    }
}
