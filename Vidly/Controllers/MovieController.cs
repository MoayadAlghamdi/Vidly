using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new List<Movie>
            {
                new Movie{Name="Shark"},
                new Movie{Name="Wall-e"}
            };
            var customers = new List<Customer>
            {
                new Customer{Name="Customer 1"},
                new Customer{Name="Customer 2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
             return View(viewModel);
        }
        public ActionResult Index()
        {

            var movie = new List<Movie>
            {
                new Movie{Name="Shark"},
                new Movie{Name="Wall-e"}
            };
            return View(movie);
        }
    }
}