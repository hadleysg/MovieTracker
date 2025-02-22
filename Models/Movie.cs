using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTracker.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public required string Title { get; set;}

 
        public  string? Director { get; set; }

        //This is saying that categoryid is a foreign key
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public required string Rating { get; set; } // G, PG, PG-13, R

        public bool Edited { get; set; } // Nullable for not required

        public string? LentTo { get; set; } // Optional

        [Required]
        public bool CopiedToPlex { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; } // Limited to 25 characters


    }

}
