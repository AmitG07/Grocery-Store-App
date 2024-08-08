using BusinessObjectLayer;
using DataAccessLayer.Helper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.ModelDAL;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class CustomerDAL : ICustomerDAL
    {
        private readonly ApplicationDbContext _context;

        public CustomerDAL(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> customers = _context.Customers.ToList();
            return customers;
        }

        public bool AddCustomer(CustomerObject customer)
        {
            IEnumerable<Customer> customers = GetCustomers();
            int count = (from c in customers where (c.EmailId == customer.EmailId) select c).ToList().Count();
            Customer customerDAL = new CustomerObjectToCustomerHelper().CustomerObjectToCustomerMapping(customer);
            if (count == 0)
            {
                customerDAL.Isadmin = false;
                _context.Customers.Add(customerDAL);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomerObject IsValid(CustomerObject customer)
        {
            var value = (_context.Customers.FirstOrDefault(c => c.EmailId == customer.EmailId));
            if(value != null)
            {
                CustomerObject customerDAL = new CustomerToCustomerObjectHelper().CustomerObjectToCustomerMapping(value);
                return customerDAL;
            }
            return null;
        }
    }
}
