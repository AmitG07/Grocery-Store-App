using BusinessLayer.Interfaces;
using BusinessObjectLayer;
using GroceryStoreAPI.Helper;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICustomerBL _customerBL;

        public LoginController(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }

        public void Index()
        {

        }

        [HttpPost]
        [Route("post")]
        public Customer Post([FromBody] CustomerLogin value)
        {
            /*string message = "";*/
            CustomerObject customer = new CustomerLoginToCustomerObjectHelper().CustomerLoginToCustomerObjectMapping(value);
            CustomerObject customerDummy = _customerBL.IsValid(customer);
            Customer cust = new CustomerObjectToCustomerHelper().CustomerObjectToCustomerMapping(customerDummy);

            if(cust != null)
            {
                return cust;
            }
            else
            {
                return null;
            }
        }
    }
}
