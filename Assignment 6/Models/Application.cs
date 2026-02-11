using System.ComponentModel.DataAnnotations;

namespace Assignment_6.Models;

public class Application
{
    [Key]
    [Required]
    public string Category { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public int Year { get; set; }

    [Required]
    public string Director { get; set; } = string.Empty;

    [Required]
    public string Rating { get; set; } = string.Empty; // must be one of G/PG/PG-13/R

    [Required]
    public bool? Edited { get; set; } // optional when creating (so nullable)

    public string? LentTo { get; set; } // optional

    [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
    public string? Notes { get; set; } // optional, max 25
}