namespace MovieTracker.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}
