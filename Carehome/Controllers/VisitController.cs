using Carehome.Areas.Dashboard.Models;
using Carehome.Areas.Dashboard.ViewModels;
using Carehome.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



namespace Carehome.Controllers
{
    public class VisitController : Controller
    {
        private readonly CareDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public VisitController(CareDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }


                    var visits = _context.Visits
             .Include(v => v.VisitServices)
                 .ThenInclude(vs => vs.Service)
             .Include(v => v.Animal)
             .Where(v => v.Animal.OwnerUser.UserName == user.UserName)
             .OrderByDescending(v => v.VisitingDate)
             .ToList();
            return View(visits);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var user =await _userManager.GetUserAsync(User);

            var animals = _context.Animals
                .Where(a => a.OwnerUser.UserName == user.UserName)
                .ToList();

            
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
        public async Task< IActionResult> Create(VisitServicesViewModel model)
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
                        VisitId=visit.Id,
                        Visit = visit
                    };

                    visit.VisitServices.Add(visitService);
                }

                _context.Visits.Add(visit);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            var services = await _context.Services.ToListAsync();
            model.Services = services.Select(s => new ServiceViewModel
            {
                Id = s.Id,
                ServiceName = s.Name,
                Price = s.Price,
                IsSelected = model.SelectedServiceIds.Contains(s.Id)
            }).ToList();

            var animals = await _context.Animals.ToListAsync();
            ViewBag.Animals = new SelectList(animals, "Id", "Name");

            return View(model);
        }
    }
}
