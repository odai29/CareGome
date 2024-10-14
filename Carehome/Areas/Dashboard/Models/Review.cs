using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carehome.Areas.Dashboard.Models
{
    [Table("Reviews",Schema ="dbo")]
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName ="nvarchar(50)")]
        public string? Name { get; set; }
        [Required]
        [StringLength(200)]
        [Column(TypeName ="nvarchar(200)")]
        public string? Subject { get; set; }
        [Required]
        public string? Email { get; set; }

        public string? Message { get; set; }
    }
}
