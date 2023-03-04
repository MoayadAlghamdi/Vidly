using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private DatabaseTest _context;
        public CustomersController()
        {
            _context = new DatabaseTest();
        }

        protected override void Dispose(bool disposing)
        {

            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var Customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(m => m.Id == id);

            if (Customer != null)
            {
                return View(Customer);
            }

            return HttpNotFound();

        }
        public ActionResult New(int? id)
        {
            Customer customer = null;
            List<MembershipType> membershipTypes = null;
            if (id != null)
            {
                customer = _context.Customers.Single(c => c.Id == id);
                membershipTypes = _context.MembershipTypes.ToList();
            }
            else
            {
                customer = new Customer();
                membershipTypes = _context.MembershipTypes.ToList();
            }
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypeList = membershipTypes,
                Customer = customer

            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypeList = _context.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerFound = _context.Customers.Single(a => a.Id == customer.Id);

                customerFound.Name = customer.Name;
                customerFound.BirthDate = customer.BirthDate;
                customerFound.MembershipTypeId = customer.MembershipTypeId;
                customerFound.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
