using Carehome.Areas.Dashboard.Models;
using Carehome.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carehome.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class MedicalExaminationController : Controller
    {
        private readonly CareDbContext _context;
        public MedicalExaminationController(CareDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var medicalExamination=_context.MedicalExaminations.ToList();

            return View(medicalExamination);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MedicalExamination medical)
        {
            if (medical != null)
            {
                _context.MedicalExaminations.Add(medical);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model=_context.MedicalExaminations.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return View("Create",model);
            }
            return RedirectToAction(nameof(model));
        }
        [HttpPost]
        public IActionResult Edit(int id,MedicalExamination medical)
        {
            var model=_context.MedicalExaminations.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                model.Id =medical.Id;
                model.Name = medical.Name;
                model.Price = medical.Price;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model=_context.MedicalExaminations.FirstOrDefault(x=>x.Id==id);
            if (model != null)
            {
                _context.MedicalExaminations.Remove(model);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
