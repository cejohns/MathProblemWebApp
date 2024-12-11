using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MathProblemWebApp.Models
{
    [Table("Definitions")]
    public class Definition
    {
        [Key]
        public int DefinitionID { get; set; }

        [Required]
        public int SubjectID { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Term { get; set; } = string.Empty;

        [Required]
        public required string DefinitionText { get; set; } = string.Empty;

        // Navigation property
        public virtual Subject? Subject { get; set; }
    }
}
