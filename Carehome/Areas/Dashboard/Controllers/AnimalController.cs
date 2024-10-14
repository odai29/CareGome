using Carehome.Areas.Dashboard.Models;
using Carehome.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Carehome.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class AnimalController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CareDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AnimalController(CareDbContext context,
            IWebHostEnvironment webHostEnvironment,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            var Animals = _context.Animals.Include(x => x.OwnerUser).ToList();
            return View(Animals);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Animal animal, IFormFile Image)
        {

            try
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

                        var user =await _userManager.GetUserAsync(User);
                        animal.OwnerUser = user;

                        _context.Animals.Add(animal);
                        _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
           
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var animal = _context.Animals.FirstOrDefault(x => x.Id == id);
            if (animal != null)
            {
                return View("Create", animal);
            }
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Animal animal, IFormFile Image)
        {
            if (animal != null)
            {
                string oldImagePath = string.Empty;
                string oldFilePath = string.Empty;
                var model = _context.Animals.FirstOrDefault(x => x.Id == id);
                if (Image != null)
                {
                    string folder = "img/ImagesAnimals";
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, folder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }
                    oldImagePath = model.Image;
                    oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, oldImagePath);
                    model.Image = Path.Combine(folder, fileName);
                }
                model.Name = animal.Name;
                model.Species = animal.Species;
                model.Gender = animal.Gender;
                model.Age = animal.Age;

                var user = await _userManager.GetUserAsync(User);
                model.OwnerUser = user;
                _context.Animals.Update(model);

                var responce = await _context.SaveChangesAsync();
                if (Convert.ToBoolean(responce))
                {
                    if (!string.IsNullOrEmpty(oldImagePath))
                    {
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }

                    }
                }
                return RedirectToAction(nameof(Index));


            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var Animal = _context.Animals.FirstOrDefault(x => x.Id == id);
            if (Animal != null)
            {
                _context.Animals.Remove(Animal);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
