using Carehome.Areas.Dashboard.Models;
using Carehome.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carehome.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class ReviewController : Controller
    {private readonly CareDbContext _context;
        public ReviewController(CareDbContext context)
        {
            _context = context;
        }
        // GET: ReviewController
        public ActionResult Index()
        {
            var model=_context.Reviews.ToList();
            return View(model);
        }

        // GET: ReviewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: ReviewController/Edit/5
        public ActionResult Edit(int id)
        {
            var model=_context.Reviews.FirstOrDefault(review => review.Id == id);
            return View("Create",model);
        }

        // POST: ReviewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Review review)
        {
            try
            {
                var model=_context.Reviews.FirstOrDefault(x=>x.Id==id);
                if (review != null)
                {
                    model.Id= review.Id;
                    model.Name=review.Name;
                    model.Subject=review.Subject;
                    model.Email=review.Email;
                    model.Message=review.Message;
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(review);
            }
        }

        

        // POST: ReviewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Review review)
        {
            try
            {
                var model=_context.Reviews.FirstOrDefault(re => review.Id==id);
                if (review != null)
                {
                    _context.Reviews.Remove(review);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
