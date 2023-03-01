using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Characters_API.Models
{
    public class Movie
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Autoincremented ID
        [StringLength(50)]
        public string MovieTitle { get; set; } = null!;
        [StringLength(50)]
        public string Genre { get; set; } = null!;
        public int ReleaseYear { get; set; }
        [StringLength(50)]
        public string Director { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string Trailer { get; set; }  = null!;
        public virtual ICollection<Character> Characters { get; set; } = new HashSet<Character>();
        public virtual Franchise Franchise { get; set; } = null!;
        public int FranchiseId { get; set; }
    }
}
