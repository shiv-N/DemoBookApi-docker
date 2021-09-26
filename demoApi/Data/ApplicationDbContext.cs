
using demoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace demoApi.Data
{
    public class ApplicationDbContext : DbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books {get;set;}
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                Name = "GaraudZhep"
            }, new Book
            {
                Id = 2,
                Name = "Shiva"
            });
        }
    }
}