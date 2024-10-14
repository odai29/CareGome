using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carehome.Areas.Dashboard.Models
{
    [Table("PetHotel", Schema = "dbo")]
    public class PetHotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [Column(TypeName = "datetime")]

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }
        
        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]

        [Display(Name ="End Date")]
        public DateTime EndDate { get; set; }
       
        [Column(TypeName = "decimal(18,3)")]
        [Display(Name = "Price Day")]
        public decimal PriceOfDay { get; set; }

       
        [Column(TypeName = "int")]
        [Display(Name = "Number of days")]
        public int NumberOfDays { get; set; }
      
        [Column(TypeName = "decimal(18,3)")]
        [Display(Name = "Total Price")]

        public decimal TotalPrice { get; set; }
        public int AnimalId { get; set; }

        public virtual Animal Animals { get; set; }
    }
}
