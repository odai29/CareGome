using Carehome.Areas.Dashboard.Models;
using Carehome.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carehome.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class FaqController : Controller
    {
        private readonly CareDbContext _context;
        public FaqController(CareDbContext context)
        {
            _context = context;
        }
        // GET: FaqController
        public ActionResult Index()
        {
            var model=_context.Faq.ToList();
            return View(model);
        }

        
        // GET: FaqController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FaqController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faq faq)
        {
            try
            {
                if (faq != null)
                {
                    _context.Faq.Add(faq);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(faq);
            }
        }

        // GET: FaqController/Edit/5
        public ActionResult Edit(int id)
        {
            var model=_context.Faq.FirstOrDefault(x => x.Id == id);
            return View("Create",model);
        }

        // POST: FaqController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Faq faq)
        {
            try
            {
                var model=_context.Faq.FirstOrDefault(x=>x.Id == id);
                if (model != null)
                {
                    model.Question=faq.Question;
                    model.Answer=faq.Answer;
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
      

        // POST: FaqController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Faq faq)
        {
            try
            {var model=_context.Faq.FirstOrDefault( x => x.Id == id);
                if (model != null)
                {
                    _context.Faq.Remove(model);
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
