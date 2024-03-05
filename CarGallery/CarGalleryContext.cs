using CarGallery.Mapping;
using CarGallery.Models;
using Microsoft.EntityFrameworkCore;

namespace CarGallery
{
    public class CarGalleryContext : DbContext
    {
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Carro> Carros { get; set; }    

        public CarGalleryContext(DbContextOptions<CarGalleryContext> options) 
            : base (options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FabricanteMapping());
            modelBuilder.ApplyConfiguration(new CarroMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
