using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scratch.Models;
using scratch.ViewModel;

namespace scratch.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        List<Customer> customer = new List<Customer> {
                new Customer{  Name = "Apratim", Id = 1},
                new Customer{  Name = "Raj", Id = 2}
            };

        [Route("Customers")]
        public ActionResult Customer()
        {
            CustomerViewModel viewModel = new CustomerViewModel
            {
                Customer = customer
            };

            return View(viewModel);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(string id)
        {
            int ID = int.Parse(id)-1;

            Customer cust = new Customer();
            cust = customer[ID];
            return View(cust);
        }
    }
}