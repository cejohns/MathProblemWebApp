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
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        
        [Required]
        public string Statement { get; set; }

        public string ProofText { get; set; }

        public string DiagramURL { get; set; }

        // Navigation Property
        public virtual Subject Subject { get; set; }
    }
}
