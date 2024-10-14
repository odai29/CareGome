using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carehome.Areas.Dashboard.Models
{
    [Table("Services", Schema = "dbo")]
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Service Name")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Display(Name = "Service Price")]
        public decimal Price { get; set; }
        public ICollection<VisitServices> visitServices { get; set; }



    }
}
