using Carehome.Data;
using Microsoft.AspNetCore.Mvc;

namespace Carehome.Controllers
{
    public class FaqController : Controller
    {
        private readonly CareDbContext _context;
        public FaqController(CareDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            var model=_context.Faq.ToList();
            return View(model);
        }
    }
}
