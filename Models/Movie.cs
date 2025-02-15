using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set;}

        [Required]
        public required string Director { get; set; }

        [Required]
        public required string Category { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public required string Rating { get; set; } // G, PG, PG-13, R

        public bool Edited { get; set; } // Nullable for not required

        public string? LentTo { get; set; } // Optional

        [StringLength(25)]
        public string? Notes { get; set; } // Limited to 25 characters
    }

}
