namespace Movie_Characters_API.Models
{
    public class Movie
    {
        public int Id { get; set; } // Autoincremented ID
        public string MovieTitle { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
    }
}
