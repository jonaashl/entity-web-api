namespace Movie_Characters_API.Models
{
    public class Franchise
    {
        public int Id { get; set; } // Autoincremented ID
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
