using Carehome.Areas.Dashboard.Models;
using Carehome.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Carehome.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class PetHotelController : Controller
    {
        private readonly CareDbContext _context;
        public PetHotelController(CareDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var model = _context.PetHotels.Include(x=>x.Animals.OwnerUser).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PetHotel petHotel)
        {
            if (petHotel != null)
            {
                var model= new PetHotel();
                model.TotalPrice = TotalPriceCalculation(petHotel);
                if (model.TotalPrice == 0)
                {
                    return View();
                }
                model.StartDate = petHotel.StartDate;
                model.EndDate = petHotel.EndDate;
                model.PriceOfDay=petHotel.PriceOfDay;
                var numberOfDays=(petHotel.EndDate - petHotel.StartDate).Days;
                model.NumberOfDays = numberOfDays;
                model.AnimalId=petHotel.AnimalId;
                
                _context.PetHotels.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(petHotel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var animals = _context.Animals.Include(x => x.OwnerUser).ToList();
            ViewBag.AnimalsList = animals.Select(a => new
            {
                Id = a.Id,
                DisplayText = a.Name + "_" + a.OwnerUser.UserName
            }).ToList();
            var model =_context.PetHotels.FirstOrDefault(x => x.Id == id);
            if(model != null)
            {
                return View("Create",model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]

        public ActionResult Edit(int id,PetHotel petHotel)
        {
            var model=_context.PetHotels.FirstOrDefault(x=>x.Id == id);
            if(model != null)
            {
                model.Id=petHotel.Id;
                model.StartDate = petHotel.StartDate;
                model.EndDate = petHotel.EndDate;
                model.PriceOfDay = petHotel.PriceOfDay;
                var numberOfDays=(petHotel.EndDate - petHotel.StartDate).Days;
                model.NumberOfDays = numberOfDays;
                model.TotalPrice = TotalPriceCalculation(petHotel);
                model.AnimalId = petHotel.AnimalId;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model =_context.PetHotels.FirstOrDefault(x=> x.Id == id);
            if( model != null )
            {
                _context.PetHotels.Remove(model);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


        public Decimal TotalPriceCalculation(PetHotel petHotel)
        {
            decimal totalPrice = 0;
            var animal=_context.PetHotels.FirstOrDefault(x=>x.Id==petHotel.AnimalId);
            if( animal != null)
            {
                var numberOfDays = (petHotel.EndDate - petHotel.StartDate).Days ;
                petHotel.NumberOfDays = numberOfDays;
                totalPrice = numberOfDays *Convert.ToDecimal( petHotel.PriceOfDay);
            }
            else
            {
                totalPrice = 0;
            }
            return totalPrice;
        }

        [Route("PetHotel/SearchAnimalByOwner")]
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
