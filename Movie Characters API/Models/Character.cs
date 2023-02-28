namespace Movie_Characters_API.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Alias { get; set; }

        public string Gender { get; set; }
        public string Picture { get; set; } // URL to image

    }
}
