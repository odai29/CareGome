using Carehome.Areas.Dashboard.Models;

namespace Carehome.ViewModels
{
    public class VmAll
    {
        public  List<Animal> Animals { get; set; }
        public List<Review> Reviews {  get; set; }
        public Review NewReview { get; set; }
        public List<Faq> Faq { get; set; }
        public List<ImageSlider> ImageSliders { get; set; }


    }
}
