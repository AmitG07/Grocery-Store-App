using BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICustomerBL
    {
        public CustomerObject IsValid(CustomerObject customer);
        public bool AddCustomer(CustomerObject customer);
    }
}
