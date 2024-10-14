using Carehome.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Carehome.Controllers
{
    public class HealthCareController : Controller
    {
        private readonly CareDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public HealthCareController(CareDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user=await _userManager.GetUserAsync(User);

            var model = _context.HealthCares.Include(x => x.MedicalExaminations).Include(x => x.Animals.OwnerUser).Where(v => v.Animals.OwnerUser.UserName == user.UserName).OrderByDescending(x=>x.Date).ToList();
            return View(model);
        }
    }
}
