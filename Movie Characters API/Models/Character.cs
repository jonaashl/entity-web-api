using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Characters_API.Models
{
    public class Character
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string? Alias { get; set; } = null!;
        [StringLength(50)]
        public string? Gender { get; set; } = null!;
        [StringLength(250)]
        public string Picture { get; set; } = null!; // URL to image
        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
        public int FranchiseId { get; set; }

    }
}
