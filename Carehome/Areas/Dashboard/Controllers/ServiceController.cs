using Carehome.Areas.Dashboard.Models;
using Carehome.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carehome.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly CareDbContext _context;
        public ServiceController(CareDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Services.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (service != null)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _context.Services.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return View("Create",model);
            }
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Service service)
        {
            var model=_context.Services.FirstOrDefault(x=>x.Id == id);
            if (model != null)
            {
                model.Id =service.Id;
                model.Name=service.Name;
                model.Price=service.Price;
                _context.SaveChanges();

            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var service = _context.Services.FirstOrDefault(x=> x.Id == id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
