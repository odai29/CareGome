using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carehome.Areas.Dashboard.Models
{
    public class ImageSlider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name ="Title")]
        [Column(TypeName ="nvarchar(50)")]
        [StringLength(50)]
        public string Title { get; set; }
        [Display(Name ="Description")]
        [Column(TypeName = "nvarchar(200)")]
        [StringLength(200)]
        public string Description { get; set; }
        [Display(Name ="Slider Image")]
        public string ImagePath { get; set; }
    }
}
