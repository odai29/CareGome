using Carehome.Areas.Dashboard.Models;
using Carehome.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Carehome.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly CareDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public AnimalController(CareDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;

        }
        public async Task< IActionResult> Index()
        {
            var user=await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            var animals=  _context.Animals.Where(x=>x.OwnerUser.Id==user.Id).ToList();
            return View(animals);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(Animal animal, IFormFile Image)
        {
            if (animal != null)
            {
                if (Image != null)
                {

                    string folder = "img/ImagesAnimals";
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, folder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }
                    animal.Image = Path.Combine(folder, fileName);
                    var user = await _userManager.GetUserAsync(User);
                    animal.OwnerUser = user;
                    _context.Animals.Add(animal);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }


        public IActionResult Gallery(string filter)
        {
            ViewBag.Filter = filter;
            List<Animal> animals;

            if (filter == "cats")
            {
                
                animals = _context.Animals
                                  .Where(x => x.Species == "Cat")
                                  .ToList();
            }
            else if (filter == "dogs")
            {
              
                animals = _context.Animals
                                  .Where(x => x.Species == "Dog")
                                  .ToList();
            }
            else
            {
               
                animals = _context.Animals.ToList();
            }

            return View(animals);
        }

    }

}

