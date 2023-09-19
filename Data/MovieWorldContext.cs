using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWorld.Data
{
    public class MovieWorldContext: DbContext
    {
        public MovieWorldContext(DbContextOptions<MovieWorldContext> options):base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<MovieCatalog> MovieCatalogs { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<MovieCatalog>()
            //    .HasKey(x => new { x.MovieId, x.CatalogId });
        }
    }
}
