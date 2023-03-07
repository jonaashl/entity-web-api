namespace Movie_Characters_API.Models.DTOs.CharacterDTOs
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Alias { get; set; } = null!;
        public List<int> Movies { get; set; } = null!;
    }
}
