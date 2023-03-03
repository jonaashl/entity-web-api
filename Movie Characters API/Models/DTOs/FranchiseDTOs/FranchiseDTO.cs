namespace Movie_Characters_API.Models.DTOs.FranchiseDTOs
{
    public class FranchiseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<int>? Movies { get; set; }
    }
}
