using Carehome.Areas.Dashboard.Models;
using Carehome.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Carehome.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class HealthCareController : Controller
    {
        private readonly CareDbContext _context;
        public HealthCareController(CareDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            var model =_context.HealthCares.Include(x=>x.MedicalExaminations).Include(x=>x.Animals.OwnerUser).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var animals = _context.Animals.Include(x=>x.OwnerUser).ToList();
            ViewBag.AnimalsList = animals.Select(x => new
            {
                Id = x.Id,
                DisplayText=x.Name + "_" + x.OwnerUser.UserName
            }).ToList();
            var examination=_context.MedicalExaminations.ToList();
            ViewBag.Examinations = examination.Select(x => new
            {
                Id=x.Id,
                ExamText=x.Name+"("+x.Price+")"
            }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(HealthCare healthCare)
        {
            if (healthCare != null)
            {
                _context.HealthCares.Add(healthCare);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var animals = _context.Animals.Include(x => x.OwnerUser).ToList();
            ViewBag.AnimalsList = animals.Select(x => new
            {
                Id = x.Id,
                DisplayText = x.Name + "_" + x.OwnerUser.UserName
            }).ToList();
            var examination = _context.MedicalExaminations.ToList();
            ViewBag.Examinations = examination.Select(x => new
            {
                Id = x.Id,
                ExamText = x.Name + "(" + x.Price + ")"
            }).ToList();
            var model = _context.HealthCares.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                return View("Create",model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Edit(int id,HealthCare healthCare)
        {
            var model=_context.HealthCares.FirstOrDefault(x=>x.Id == id);
            if (model != null)
            {
                model.TreatmentType=healthCare.TreatmentType;
                model.TreatmentDescription=healthCare.TreatmentDescription;
                model.Treatmentprice=healthCare.Treatmentprice;
                model.Date=healthCare.Date;
                model.AnimalId=healthCare.AnimalId;
                model.MedicalExaminationId=healthCare.MedicalExaminationId;
                model.TotalPrice=healthCare.TotalPrice;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model=_context.HealthCares.FirstOrDefault(x=> x.Id == id);
            if(model != null)
            {
                _context.HealthCares.Remove(model);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
