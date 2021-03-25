using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scratch.Models;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace scratch.Controllers
{
    public class CustomerController : Controller
    {
        //we should have named CustoemrDBContext as ApplicationDBContext

        private CustomerDBContext _context;

        public CustomerController()
        {
            _context = new CustomerDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customer = _context.Customers; // deferred until we iterate
            return View(customer.Include(c => c.MembershipType).ToList()); ;
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id); //this return the customer object with
            return View(customer);
        }
    }
}