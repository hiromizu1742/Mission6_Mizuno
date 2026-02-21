using Microsoft.EntityFrameworkCore;

namespace Assignment_6.Models;

public class MoviesContext : DbContext
{
    public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) //Constructor
    {
    }

    public DbSet<Movies> Movies { get; set; }
}
