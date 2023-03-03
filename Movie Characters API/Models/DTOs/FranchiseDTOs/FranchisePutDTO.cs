namespace Movie_Characters_API.Models.DTOs.FranchiseDTOs
{
    public class FranchisePutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
