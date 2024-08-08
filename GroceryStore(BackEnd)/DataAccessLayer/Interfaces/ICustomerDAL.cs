using BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface ICustomerDAL
    {
        public CustomerObject IsValid(CustomerObject customer);
        public bool AddCustomer(CustomerObject customer);
    }
}
