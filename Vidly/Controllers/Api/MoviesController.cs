using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private DatabaseTest _context;
        protected readonly IMapper _mapper;
        private readonly MapperConfiguration _config;

        public MoviesController()
        {
            _context = new DatabaseTest();
            _config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = _config.CreateMapper();
        }

        // GET /api/movies
        public IHttpActionResult GetMovies()
        {
            var movieDto = _context.Movies.ToList().Select(_mapper.Map<Movie, MovieDto>);
            return Ok(movieDto);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return BadRequest();
            else
                return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var existingMovie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (existingMovie == null)
                return NotFound();

            _mapper.Map(movieDto, existingMovie);

            _context.SaveChanges();

            return Ok();
        }
        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
