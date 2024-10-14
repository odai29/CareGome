using Carehome.Areas.Dashboard.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Carehome.Areas.Dashboard.ViewModels
{
    public class VisitServicesViewModel
    {
        public int Id { get; set; }
        [Required]
        public int AnimalId { get; set; }
        public List<Animal> Animals { get; set; } = new List<Animal>();

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public decimal TotalPrice { get; set; }
        public string Description { get; set; }

        public List<int> SelectedServiceIds { get; set; } = new List<int>();

        public List<ServiceViewModel> Services { get; set; } = new List<ServiceViewModel>();

    }
 
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }

}
