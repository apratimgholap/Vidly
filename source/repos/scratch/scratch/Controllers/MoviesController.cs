using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scratch.Models;
using scratch.ViewModel;

namespace scratch.Controllers
{
    public class MoviesController : Controller
    {
        private CustomerDBContext _context;

        public MoviesController()
        {
            _context = new CustomerDBContext();
        }

        protected override void Dispose(bool disposing) 
        {
            _context.Dispose();
        }

        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = genres
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditForm(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var genres = _context.Genres.ToList();

            if (movie == null)
                return HttpNotFound(); 

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genre = genres
            };
            return View("MovieForm",viewModel);
        }

       
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {

                var movieInContextDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInContextDb.Name = movie.Name;
                movieInContextDb.NoOfStockAvailable = movie.NoOfStockAvailable;
                movieInContextDb.ReleaseDate = movie.ReleaseDate;
                movieInContextDb.GenreType = movie.GenreType;
            }

            try

            {
                _context.SaveChanges();
            }

            catch (DbEntityValidationException e) //deep dive exceptions
            {

                Console.WriteLine(e);
            }
            return RedirectToAction("Index","Movies");
        }
        public ActionResult Index()
        {
            var movie = _context.Movies;
            return View(movie.Include(m => m.GenreType));
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies;
            return View(movie.Include(t => t.GenreType).FirstOrDefault(t => t.GenreId == id)); 
            // Single worked in case of 'Customer' because only single customer was selected at end
            // But in case of 'Movie' because multiple movie will be selected as multiple movies can have same genres 
        }


        //Some Previous Code 

        //var viewResult = new ViewResult();
        //viewResult.ViewData.Model = movie;

        //return Content("Hello World");
        //return HttpNotFound();
        //return new EmptyResult();
        //return RedirectToAction("Index","Home",new {page=1,SortBy=name});


        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year,int month)
        //{
        //    return Content("Month = " + month + " " + "Year ="+year);
        //}



    }
}