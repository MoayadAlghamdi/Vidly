using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private DatabaseTest _context;

        public CustomersController()
        {
            _context = new DatabaseTest();
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer =  _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return BadRequest();
            else
                return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)  
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id , CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (existingCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, existingCustomer);

            _context.SaveChanges();
        }
        [HttpDelete]
        // DELETE /api/customers/1
        public void DeleteCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
