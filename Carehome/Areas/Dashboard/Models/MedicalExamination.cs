using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carehome.Areas.Dashboard.Models
{
    [Table("MedicalExaminations", Schema = "dbo")]
    public class MedicalExamination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Name Examination")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Price { get; set; }
       
    }
}
