using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWorld.Data
{
    public class Movie
    {
        public Movie()
        {
            this.Catalogs = new List<MovieCatalog>();
        }

        public int MovieId { get; set; }

        [Required]
        [MaxLength(64)]
        [Display(Name ="Title")]
        public string MovieName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }
        [Display(Name ="Photo")]
        public string MoviePhoto { get; set; }

        public ICollection<MovieCatalog> Catalogs { get; set; }
    }
}
