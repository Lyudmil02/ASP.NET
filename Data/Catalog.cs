using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWorld.Data
{
    public class Catalog
    {
        public Catalog()
        {
            this.Movies = new List<MovieCatalog>();
        }

        public int CatalogId { get; set; }

        [Required]
        [MaxLength(64)]
        [Display(Name ="Name")]
        public string CatalogName { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<MovieCatalog> Movies { get; set; }
    }
}
