using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scratch.Models;
using scratch.ViewModel;

namespace scratch.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        


        [Route("movies/random")]
        public ActionResult Random()
        {
            Movie movie = new Movie()
            {
                Name = "Shawshank",
                Id = 1
            };

            List<Customer> customer = new List<Customer> {
                new Customer{  Name = "Apratim", Id = 1},
                new Customer{  Name = "Raj", Id = 2}
            };

            RandomViewModel viewModel = new RandomViewModel()
            {
                Customers = customer,
                Movie = movie
            };
            return View(viewModel);
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model = movie;

            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index","Home",new {page=1,SortBy=name});

        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content("Month = " + month + " " + "Year ="+year);
        }
        
        public ActionResult Edit(int i)
        { 
            return Content(string.Format("The passed number is = {0}", i));
        }
        public ActionResult Index(int? pageIndex=1,string sortBy="Name")
        {
            return Content(string.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
        }

       
    }
}