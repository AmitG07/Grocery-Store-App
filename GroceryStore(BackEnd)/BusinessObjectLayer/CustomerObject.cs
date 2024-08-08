using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer
{
    public class CustomerObject
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool Isadmin { get; set; }
    }
}
