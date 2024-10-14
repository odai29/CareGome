using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carehome.Areas.Dashboard.Models
{
    [Table("Animals", Schema = "dbo")]
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Name Animal")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Species")]
        public string Species { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        
        [Column(TypeName = "int")]
        [Display(Name = "Age")]
        public int Age { get; set; }
        
        [Display(Name = "Animal Image ")]
        public string Image { get; set; }
        [Display(Name = "Owner")]
        public virtual IdentityUser OwnerUser { get; set; }
    }
}
