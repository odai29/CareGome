using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carehome.Areas.Dashboard.Models
{
    [Table("VisitServices", Schema = "dbo")]
    public class VisitServices
    {


        [Required]
        [Display(Name = "Service Name")]
        public required int ServiceId { get; set; }
        public  virtual Service Service { get; set; }
        [Required]
       
        public required int VisitId { get; set; }

        public  virtual Visit Visit { get; set; }
    }
}
