using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Carehome.ViewModels;
using Carehome.Areas.Dashboard.Models;
using Carehome.Areas.Dashboard.ViewModels;

namespace Carehome.Data
{
    public class CareDbContext : IdentityDbContext
    {
        public CareDbContext(DbContextOptions<CareDbContext> options) : base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<VisitServices> VisitServices { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<PetHotel> PetHotels { get; set; }
        public DbSet<MedicalExamination> MedicalExaminations { get; set; }
        public DbSet<HealthCare> HealthCares { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Faq> Faq { get; set; }
        public DbSet<ImageSlider> ImagesSliders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "sec");
            builder.Entity<IdentityRole>().ToTable("Roles", "sec");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "sec");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "sec");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "sec");
            builder.Entity<IdentityUser>().ToTable("Users", "sec");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "sec");

            builder.Entity<VisitServices>().HasKey(x => new { x.ServiceId, x.VisitId });
            
        }
        
    }
}
