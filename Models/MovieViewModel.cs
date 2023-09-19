using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWorld.Models
{
    public class MovieViewModel
    {
        [Required]
        [MaxLength(64)]
        [Display(Name = "Title")]
        public string MovieName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        [Display(Name ="Photo")]
        public IFormFile Photo { get; set; }
    }
}
