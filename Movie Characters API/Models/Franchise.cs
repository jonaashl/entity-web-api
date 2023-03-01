using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Characters_API.Models
{
    public class Franchise
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Autoincremented ID
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
