using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Genres field is required")]
        public string Genres { get; set; }
        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "The Release Date field is required")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Number in Stock")]
        [Required(ErrorMessage = "The Stack field is required")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        public int Stack { get; set; }
    }
}