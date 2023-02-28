namespace Movie_Characters_API.Models
{
    public class Movie
    {
        public int Id { get; set; } // Autoincremented ID
        public string MovieTitle { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string Trailer { get; set; }  = null!;
        public virtual ICollection<Character> Characters { get; set; } = new HashSet<Character>();
        public virtual Franchise Franchise { get; set; } = null!;
    }
}
