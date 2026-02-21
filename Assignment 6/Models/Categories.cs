using System.ComponentModel.DataAnnotations;

namespace Assignment_6.Models;

public class Categories
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    // Navigation property for all movies in this category.
    public List<Movies> Movies { get; set; } = new();
}
