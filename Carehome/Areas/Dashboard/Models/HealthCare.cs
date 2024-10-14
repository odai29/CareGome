using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carehome.Areas.Dashboard.Models
{
    [Table("HealthCare", Schema = "dbo")]
    public class HealthCare
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Treatment Type")]
        public string TreatmentType { get; set; }
        [Required]
        [StringLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Treatment Description")]
        public string TreatmentDescription { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Display(Name = "Treatment Price")]
        public decimal Treatmentprice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
        [Display(Name ="Animal")]
        public int AnimalId { get; set; }
        public virtual Animal Animals { get; set; }
        public int MedicalExaminationId { get; set; }
        public virtual MedicalExamination MedicalExaminations { get; set;}
       
    }
}
