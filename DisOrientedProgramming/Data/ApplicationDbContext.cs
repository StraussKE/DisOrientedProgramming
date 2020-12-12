using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using DisOrientedProgramming.Models;

namespace DisOrientedProgramming.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
            // replace with actual DbSets
        //public DbSet<Meeting> Meetings { get; set; }

        public DbSet<ForumPost> forumPosts { get; set; }
        public DbSet<ForumTopic> forumTopics { get; set; }
        public DbSet<AppUser> appUsers { get; set; }

        public DbSet<SurveyModel> surveyModels { get; set; }

        public DbSet<ResourceLink> resourceLinks { get; set; }

            // if many to many bridges required
        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                       

            modelBuilder.Entity<Speaker>().Ignore(s => s.SpeakerAccount);

            // Speaker capable of being tied to a single AppUser account

            modelBuilder.Entity<Speaker>()
                .HasOne(s => s.SpeakerAccount)
                .WithMany()
                .IsRequired(false);

        } */


        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<AppUser> userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //Set Roles that will not be changed
            string[] roleNames = { "Admins", "MeetingHost", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

        }

        public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<AppUser> userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string username = configuration["Data:AdminUser:Name"];
            string firstName = configuration["Data:AdminUser:FirstName"];
            string lastName = configuration["Data:AdminUser:LastName"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];
            var adminUser = await userManager.FindByNameAsync(username);
            if (adminUser == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                AppUser user = new AppUser
                {
                    UserName = username,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
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
