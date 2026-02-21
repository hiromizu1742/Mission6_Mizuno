using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_6.Models;

public class Movies
{
    [Key]
    public int MovieId { get; set; }
    public int? CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Categories? Category { get; set; }

    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    public int Edited { get; set; }
    public string? LentTo { get; set; }
    public int CopiedToPlex { get; set; }
    public string? Notes { get; set; }
}
