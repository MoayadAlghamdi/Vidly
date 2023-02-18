using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "The Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Genres is required")]
        public string Genres { get; set; }
        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "The Release Date is required")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime  DateAdded { get; set; }
        [Display(Name = "Number in Stock")]
        [Required(ErrorMessage = "The Stack is required")]
        public int Stack { get; set; }
    }
}