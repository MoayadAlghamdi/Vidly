﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;


namespace Vidly.Models
{
    public class RandomMovieViewModel
    {
        public List<Movie> Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}