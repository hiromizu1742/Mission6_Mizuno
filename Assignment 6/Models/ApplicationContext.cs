using Microsoft.EntityFrameworkCore;
namespace Assignment_6.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) //Constructor
    {
    }
    public DbSet<Application>Applications{get; set;}
}