using Carehome.Data;
using Carehome.Areas.Dashboard.Models;
using Carehome.Models;
using Carehome.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Carehome.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly CareDbContext _context;
		public HomeController(ILogger<HomeController> logger,UserManager<IdentityUser> userManager,CareDbContext context)
		{
			_logger = logger;
			_userManager = userManager;
			_context = context;
		}

		public IActionResult Index()
		{
            var userCount = _context.Users.Count();
            ViewBag.UserCount = userCount;
			var animalCount= _context.Animals.Count();
            ViewBag.AnimalCount= animalCount;
            var PetHotelCount =  _context.PetHotels.Count(); 
           ViewBag.PetHotelCount = PetHotelCount;
			var imageSlider =_context.ImagesSliders.Take(6).ToList();
            var animals=_context.Animals.Take(12).ToList();
			var reviews=_context.Reviews.ToList();
			var faq=_context.Faq.ToList();
			var viewModel = new VmAll
			{
				Animals = animals,
				Reviews = reviews,
				Faq = faq,
				ImageSliders = imageSlider,
                NewReview = new Review()
            };
			return View(viewModel);
		}
		[HttpPost]
		public ActionResult SubmitReview(VmAll vm)
		{
			//ModelState.Remove("Animals");
			//ModelState.Remove("Faq");
		

            
                var review = vm.NewReview;
                
                _context.Reviews.Add(review);
                 _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
             
        }
		public IActionResult AboutUs()
		{
			return View();
		}

		public IActionResult PetHotel()
        {
            return View();
        }

        public async Task< IActionResult> PetHotelList()
		{
            var animal = _context.Animals.ToList();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            var hotel = _context.PetHotels
          .Where(v => v.Animals.OwnerUser.UserName == user.UserName).OrderByDescending(v => v.StartDate)
          .ToList();
			return View(hotel);
        }
		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult HealthCare()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
