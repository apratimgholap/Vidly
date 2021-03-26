using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scratch.Models;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using scratch.ViewModel;

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

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var cust = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (cust == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = cust,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel); //we are passing a view and model to be used by the view !
        }

        [HttpPost] //if actions are modifying data they should never get access by httpget method
        public ActionResult Save(Customer customer) //request data mapped to object - model binding
        {
            //if (!ModelState.IsValid)
            //{

            //    var viewModel = new CustomerFormViewModel
            //    { 
            //    }
            //    return View("viewModel");
            //}

            if (customer.Id==0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }
            _context.SaveChanges();     //changes are saved in form of transaction (ALL or NOTHING)
            return RedirectToAction("Index","Customer");
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