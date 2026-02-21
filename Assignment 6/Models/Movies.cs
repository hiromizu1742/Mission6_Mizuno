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

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; } = string.Empty;

    [Range(1888, 9999, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }

    [Required(ErrorMessage = "Edited is required.")]
    [Range(0, 1, ErrorMessage = "Edited must be Yes or No.")]
    public int Edited { get; set; }

    public string? LentTo { get; set; }

    [Required(ErrorMessage = "CopiedToPlex is required.")]
    [Range(0, 1, ErrorMessage = "CopiedToPlex must be Yes or No.")]
    public int CopiedToPlex { get; set; }
    public string? Notes { get; set; }
}
