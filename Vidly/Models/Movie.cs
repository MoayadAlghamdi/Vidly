﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime  DateAdded { get; set; }
        public int Stack { get; set; }
    }
}