using Carehome.Areas.Dashboard.Models;
using Carehome.Areas.Dashboard.ViewModels;
using Carehome.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Carehome.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class VisitController : Controller
    {
        private readonly CareDbContext _context;

        public VisitController(CareDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {



            var visits = _context.Visits
                .Include(v => v.VisitServices)
                    .ThenInclude(vs => vs.Service)
                .Include(v => v.Animal)
                .OrderByDescending(v => v.VisitingDate)
                .ToList();

            return View(visits);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var animals = _context.Animals.ToList();
            ViewBag.Animals = new SelectList(animals, "Id", "Name");

            var services = _context.Services.ToList();
            var model = new VisitServicesViewModel
            {
                Date = DateTime.Now,
                Services = services.Select(s => new ServiceViewModel
                {
                    Id = s.Id,
                    ServiceName = s.Name,
                    Price = s.Price,
                    IsSelected = false
                }).ToList()
            };

            return View(model);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VisitServicesViewModel model)
        {

            if (ModelState.IsValid)
            {
                var visit = new Visit
                {
                    AnimalId = model.AnimalId,
                    VisitingDate = model.Date,
                    Description = model.Description,
                    VisitServices = new List<VisitServices>()
                };
                foreach (var serviceId in model.SelectedServiceIds)
                {
                    var visitService = new VisitServices
                    {
                        ServiceId = serviceId,
                        VisitId = visit.Id,
                        Visit = visit
                    };

                    visit.VisitServices.Add(visitService);
                }

                _context.Visits.Add(visit);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }


            return View(model);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var visit = _context.Visits
         .Include(v => v.VisitServices)
             .ThenInclude(vs => vs.Service)
         .FirstOrDefault(v => v.Id == id);

            if (visit == null)
            {
                return NotFound();
            }


            var animals = _context.Animals.ToList();
            ViewBag.Animals = new SelectList(animals, "Id", "Name", visit.AnimalId);

            var services = _context.Services.ToList();


            var model = new VisitServicesViewModel
            {
                AnimalId = visit.AnimalId,
                Date = visit.VisitingDate,
                Description = visit.Description,
                Services = services.Select(s => new ServiceViewModel
                {
                    Id = s.Id,
                    ServiceName = s.Name,
                    Price = s.Price,
                    IsSelected = visit.VisitServices.Any(vs => vs.ServiceId == s.Id)
                }).ToList(),
                SelectedServiceIds = visit.VisitServices.Select(vs => vs.ServiceId).ToList()
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, VisitServicesViewModel model)
        {
            if (ModelState.IsValid)
            {

                var visit = _context.Visits
                    .Include(v => v.VisitServices)
                    .FirstOrDefault(v => v.Id == id);

                if (visit == null)
                {
                    return NotFound();
                }


                visit.AnimalId = model.AnimalId;
                visit.VisitingDate = model.Date;
                visit.Description = model.Description;


                visit.VisitServices.Clear();
                foreach (var serviceId in model.SelectedServiceIds)
                {
                    var visitService = new VisitServices
                    {
                        ServiceId = serviceId,
                        VisitId = visit.Id
                    };
                    visit.VisitServices.Add(visitService);
                }

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }


            return View(model);
        }
        private bool VisitExists(int id)
        {
            return _context.Visits.Any(e => e.Id == id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var visit = _context.Visits
         .Include(v => v.VisitServices)
         .FirstOrDefault(v => v.Id == id);

            if (visit == null)
            {
                return NotFound();
            }

            _context.VisitServices.RemoveRange(visit.VisitServices);
            _context.Visits.Remove(visit);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [Route("Visit/SearchAnimalByOwner")]
        [HttpGet]
        public async Task<IActionResult> SearchAnimalByOwner(string ownerName)
        {
            if (string.IsNullOrEmpty(ownerName))
            {
                return Json(new { message = "Owner name is required." });
            }

          
            var owner = await _context.Users.FirstOrDefaultAsync(u => u.UserName == ownerName);
            if (owner == null)
            {
                return Json(new { message = "Owner not found." });
            }

           
            var animals = await _context.Animals
                .Where(a => a.OwnerUser.Id == owner.Id)
                .Select(a => new
                {
                    Id = a.Id,
                    Name = a.Name,
                   
                })
                .ToListAsync();

            if (!animals.Any())
            {
                return Json(new { message = "No animals found for this owner." });
            }

            return Json(animals);
        }






       
        

    }
}





