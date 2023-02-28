namespace Movie_Characters_API.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Alias { get; set; } = null!;

        public string Gender { get; set; } = null!;
        public string Picture { get; set; } = null!; // URL to image
        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

    }
}
