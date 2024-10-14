using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NuGet.Configuration;

namespace Carehome.Areas.Dashboard.Models
{
    [Table("Visit", Schema = "dbo")]
    public class Visit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Animal Name")]
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [StringLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        [Display(Name = "Visiting Date")]
        public DateTime VisitingDate { get; set; }

        public virtual ICollection<VisitServices> VisitServices { get; set; }
    }
}
