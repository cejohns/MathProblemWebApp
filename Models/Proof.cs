using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MathProblemWebApp.Models
{
    [Table("Proofs")]
    public class Proof
    {
        [Key]
        public int ProofID { get; set; }

        [Required]
        public int SubjectID { get; set; }

        [Required]
        [MaxLength(500)]
        public required string Statement { get; set; } = string.Empty;

        [Required]
        public required string ProofText { get; set; } = string.Empty;

        // Diagram URL can be nullable if not always provided
        public string? DiagramURL { get; set; }

        // Navigation property
        public virtual Subject? Subject { get; set; }
    }
}
