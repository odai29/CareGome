using Carehome.Data;
using Microsoft.AspNetCore.Mvc;

namespace Carehome.Controllers
{
    public class GroomingController : Controller
    {
        public readonly CareDbContext _context;
        public GroomingController(CareDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var service= _context.Services.ToList();    
            return View(service);
        }
    }
}
