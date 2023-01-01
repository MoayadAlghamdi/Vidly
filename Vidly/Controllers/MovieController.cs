using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private DatabaseTest _context;
        private List<Movie> _movies;
        private List<Customer> _customers;
        public MovieController()
        {
            _context = new DatabaseTest();
            _movies = _context.Movies.ToList();
            _customers = _context.Customers.ToList();
        }

        protected override void Dispose(bool disposing)
        {

            _context.Dispose();
        }
        // GET: Movie/Random
        public ActionResult Random()
        {
            var viewModel = new RandomMovieViewModel
            {
                Movie = _movies,
                Customers = _customers
            };
             return View(viewModel);
        }
        public ActionResult Index()
        {

            return View(_movies);
        }
        //Details/id
        public ActionResult Details(int id)
        {
            Movie movieDetail = _movies.FirstOrDefault(x => x.Id == id);
            return View(movieDetail);

        }

    }
}