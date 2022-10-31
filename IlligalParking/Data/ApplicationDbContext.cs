using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IlligalParking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IlligalParking.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Parking>().ToTable("Parking");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Complain>().ToTable("Complain");

            modelBuilder.Entity<Parking>().HasData(
               new Parking { TypeID = 1, Name = "Visitor Parking", UsableTo = "Anyone", Restriction = "May not leave Vehicle overnight" },
               new Parking { TypeID = 2, Name = "Residence students Parking", UsableTo = "Students that resides on campus", Restriction = "Car Must be in working condition." },
               new Parking { TypeID = 3, Name = "Staff Parking", UsableTo = "Staff of the specific faculty", Restriction = "May not park overnight" },
               new Parking { TypeID = 4, Name = "Reserved Parking", UsableTo = "Marked parking for the officials", Restriction = "No Restriction" }
               );

        }
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider,
               IConfiguration configuration)
        {
            UserManager<IdentityUser> userManager =
                serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string username = configuration["Data:AdminUser:Name"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];


            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                IdentityUser user = new IdentityUser
                {
                    UserName = username,
                    Email = email
                };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
