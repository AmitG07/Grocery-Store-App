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
    public class RegisterController : ControllerBase
    {
        private readonly ICustomerBL _customerBL;

        public RegisterController(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }

        [HttpPost]
        [Route("post")]
        public Customer Post([FromBody] Customer value)
        {
            /*string message = "";*/

            if (value != null)
            {
                CustomerObject customer = new CustomerToCustomerObjectHelper().CustomerToCustomerObjectMapping(value);
                if (ModelState.IsValid)
                {
                    if (_customerBL.AddCustomer(customer))
                    {
                        /*message = "User Registered";*/
                        return value;
                    }
                    else
                    {
                        /*message = "User Already Registered with same Email Address";*/
                        return null;
                    }
                }
                
            }
            return value;
            /*return Ok(message);*/
        }
    }
}
