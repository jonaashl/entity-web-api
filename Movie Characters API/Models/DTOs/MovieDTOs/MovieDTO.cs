namespace Movie_Characters_API.Models.DTOs.MovieDTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public List<int>? Characters { get; set; }
        public int? FranchiseId { get; set; }
    }
}
