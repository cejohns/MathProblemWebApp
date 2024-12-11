using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MathProblemWebApp.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Navigation Properties
        public virtual ICollection<Proof> Proofs { get; set; } = new HashSet<Proof>();
        public virtual ICollection<Definition> Definitions { get; set; } = new HashSet<Definition>();
    }
}
