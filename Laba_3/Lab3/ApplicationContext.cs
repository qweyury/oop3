using Lab3.Models;
using Microsoft.EntityFrameworkCore;


namespace Lab3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Director> Directors => Set<Director>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=movies.db");  
        }
    }
}
