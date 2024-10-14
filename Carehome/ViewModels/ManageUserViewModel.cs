using System.ComponentModel.DataAnnotations;

namespace Carehome.ViewModels
{
    public class ManageUserViewModel
    {
       
        public string UserName { get; set;}
        [Required]
        public string PhoneNumber { get; set;}

    }
}
