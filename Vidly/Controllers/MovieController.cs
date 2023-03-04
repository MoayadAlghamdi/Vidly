using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult Edit(int id)
        {
            Movie movie = null;
            List<string> Genre = null;

            movie = _movies.FirstOrDefault(x => x.Id == id);
            Genre = _context.Movies.Select(x => x.Genres).Distinct().ToList();

            var viewModel = new NewMovieViewModel
            {
                GenreList = Genre,
                Movie = movie

            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            var movieFound = _context.Movies.Single(a => a.Id == movie.Id);
            List<string> Genre = null;
            Genre = _context.Movies.Select(x => x.Genres).Distinct().ToList();
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    GenreList = Genre,
                    Movie = movie
                };
                return View(viewModel);
            }

            movieFound.Name = movie.Name;
            movieFound.Genres = movie.Genres;
            movieFound.DateAdded = DateTime.Now;
            movieFound.ReleaseDate = movie.ReleaseDate;
            movieFound.Stack = movie.Stack;

            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult New()
        {
            Movie movie = null;
            List<string> Genre = null;
            Genre = _context.Movies.Select(x => x.Genres).Distinct().ToList();
            var viewModel = new NewMovieViewModel
            {
                GenreList = Genre,
                Movie = movie

            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    GenreList = _context.Movies.Select(x => x.Genres).Distinct().ToList()
                };
                return View("New", viewModel);
            }

            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}