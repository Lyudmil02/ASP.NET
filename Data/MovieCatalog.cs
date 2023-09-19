using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWorld.Data
{
    public class MovieCatalog
    {
        [Key]
        public int MovieCatalogId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }
    }
}
