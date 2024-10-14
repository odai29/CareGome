using Carehome.Areas.Dashboard.Models;
using Carehome.Data;
using Microsoft.AspNetCore.Mvc;

namespace Carehome.Controllers
{
    public class ReviewController : Controller
    {
        private readonly CareDbContext _context;
        public ReviewController(CareDbContext context)
        {
            _context = context;
        }
        // GET: ReviewController
        public ActionResult Index()
        {
            var model = _context.Reviews.ToList();
            return View(model);
          
        }

       
        // GET: ReviewController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReviewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Review review)
        {
            try
            {
                if (review != null)
                {
                    _context.Reviews.Add(review);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(review);
            }
        }
    }
}
