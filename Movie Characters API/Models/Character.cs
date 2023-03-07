using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Characters_API.Models
{
    public class Character
    {
        public Character()
        {
            Movies = new HashSet<Movie>();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string? Alias { get; set; }
        [StringLength(50)]
        public string? Gender { get; set; }
        [StringLength(250)]
        public string? Picture { get; set; } // URL to picture
        public virtual ICollection<Movie> Movies { get; set; }
        public int? FranchiseId { get; set; }
    }
}
