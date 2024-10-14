using Carehome.Areas.Dashboard.Models;
using Carehome.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Carehome.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ImageController : Controller
    {
        private readonly CareDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageController(CareDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            var model = _context.ImagesSliders.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ImageSlider model, IFormFile ImagePath)
        {

            try
            {
                if (model != null)
                {
                    if (ImagePath != null)
                    {

                        string folder = "img/ImageSlider";
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, folder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            ImagePath.CopyTo(stream);
                        }
                        model.ImagePath = Path.Combine(folder, fileName);



                        _context.ImagesSliders.Add(model);
                        _context.SaveChanges();
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
            var model = _context.ImagesSliders.FirstOrDefault(x => x.Id == id);
            return View("Create", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ImageSlider slider, IFormFile ImagePath)
        {
            if (slider != null)
            {
                string oldImagePath = string.Empty;
                string oldFilePath = string.Empty;
                var model = _context.ImagesSliders.FirstOrDefault(x => x.Id == id);
                if (ImagePath != null)
                {
                    string folder = "img/ImagesAnimals";
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, folder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImagePath.CopyTo(stream);
                    }
                    oldImagePath = model.ImagePath;
                    oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, oldImagePath);
                    model.ImagePath = Path.Combine(folder, fileName);
                }
                model.Title = slider.Title;
                model.Description = slider.Description;
                _context.ImagesSliders.Update(model);

                var responce = _context.SaveChanges();
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
        public ActionResult Delete(int id)
        {
            var image = _context.ImagesSliders.FirstOrDefault(x => x.Id == id);
            if (image != null)
            {
                _context.ImagesSliders.Remove(image);
                _context.SaveChanges();

            }
            return RedirectToAction(nameof(Index));
        }
    }

}
