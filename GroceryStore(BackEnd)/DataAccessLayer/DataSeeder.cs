using DataAccessLayer.ModelDAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class DataSeeder
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.Customers.Any())
                {

                    var customers = new List<Customer>
                    {
                        new Customer {FullName="admin1", EmailId = "admin1@grocery.com",PhoneNumber="1234567899", Password = "P@ssword1", Isadmin=true },
                        new Customer {FullName="admin2", EmailId = "admin2@grocery.com",PhoneNumber="1234567898", Password = "P@ssword2", Isadmin=true }
                    };

                    context.Customers.AddRange(customers);
                    context.SaveChanges();
                }
            }
        }
    }
}
