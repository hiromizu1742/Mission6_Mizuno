using Microsoft.EntityFrameworkCore;

namespace Assignment_6.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) //Constructor
    {
    }
    public DbSet<Application>Applications{get; set;}
    public DbSet<Movies> Movies { get; set; }
    public DbSet<Categories> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movies>()
            .HasOne(m => m.Category)
            .WithMany(c => c.Movies)
            .HasForeignKey(m => m.CategoryId);
    }
}
