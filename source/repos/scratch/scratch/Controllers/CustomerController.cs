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


        // Understand Dispose.
       
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public CustomerController()
        {
            _context = new CustomerDBContext();
        }

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();  //here genere/membershipType is not collection how we are iterating over the list ? // We were thinking it in wrong way here we are not accessing MembershipTypes Class we are accessing the database see _context :}
                     // So We need to convert the values of DB membershiptype which are different membershipType object into list :)
                     // then we are passing those values to viewModel which has a enumerable to just iterate through these values.

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
        public ActionResult Save(Customer customer) //request data(the data we filled) mapped to model here its customer - model binding
        {
            //if (!ModelState.IsValid)
            //{

            //    var viewModel = new CustomerFormViewModel
            //    { 
            //    }
            //    return View("viewModel");
            //}

            if (customer.Id==0) 
                _context.Customers.Add(customer);  //here we just store the data in memory not database. context change tracking mechanism idetifies modification and runs the corresponidng sql queries on database
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