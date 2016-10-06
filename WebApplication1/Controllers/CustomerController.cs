using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : ApiController
    {
        private Customer[] _customers;

        private Customer[] Customers => _customers ?? (_customers = GetCustomers());

        private Customer[] GetCustomers()
        {
            var customers = new List<Customer>();
            for (var i = 0; i < 100; i++)
            {
                customers.Add(new Customer
                {
                    Id = i,
                    FirstName = "FirstName_" + i,
                    LastName = "LastName_" + i
                });
            }

            return customers.ToArray();
        }

        public IEnumerable<Customer> GetAllProducts()
        {
            return Customers;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = Customers.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}