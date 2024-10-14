using System.ComponentModel.DataAnnotations;

namespace Carehome.ViewModels
{
    public class RoleFormViewModel
    {
        
        [Required]
        [Display(Name = "Role Name"), StringLength(100)]
        public string Name { get; set; }
    }
}
