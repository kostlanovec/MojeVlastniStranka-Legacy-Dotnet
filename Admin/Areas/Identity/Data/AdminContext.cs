using Admin.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Admin.Data
{
    public class AdminContext : IdentityDbContext<AdminUser>
    {
        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });

            // a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<AdminUser>();

            // Seeding the User to AspNetUsers table
            modelBuilder.Entity<AdminUser>().HasData(
                new AdminUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "info@kostlanovec.cz",
                    NormalizedUserName = "INFO@KOSTLANOVEC.CZ",
                    EmailConfirmed = true,
                    Email = "INFO@KOSTLANOVEC.CZ",
                    NormalizedEmail = "info@kostlanovec.cz",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(new AdminUser(), "[REDACTED]")
                }
            );

            // Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );
        }
    }
}