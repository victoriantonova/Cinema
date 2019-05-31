using Cinema.DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Subcategory> Subcategories { get; set; }
        //public DbSet<Region> Regions { get; set; }
        //public DbSet<City> Cities { get; set; }
        //public DbSet<ImagesGallery> ImagesGalleries { get; set; }
        //public DbSet<Post> Posts { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Operation> Operations { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Films> Films { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<GenresOfFilm> GenresOfFilm { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<ActorsOfFilm> ActorsOfFilm { get; set; }
        public DbSet<Cinemas> Cinemas { get; set; }
        //-------------------------------------
        public DbSet<Seances> Seances { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<SeatsBusy> SeatsBusy { get; set; }








        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
