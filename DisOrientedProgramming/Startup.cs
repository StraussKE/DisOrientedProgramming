using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Runtime.InteropServices;

using DisOrientedProgramming.Data;
using DisOrientedProgramming.Models;

namespace DisOrientedProgramming
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
            services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.ConfigureApplicationCookie(opts =>
			{
				opts.LoginPath = "/Identity/Account/Login";
				opts.LogoutPath = "/Identity/Account/Logout";
				opts.AccessDeniedPath = "/Home/AccessDenied";
				opts.ExpireTimeSpan = TimeSpan.FromMinutes(5);
				opts.SlidingExpiration = true;
			});

			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				// Assuming that SQL Server is installed on Windows
				services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("SQLServerConnection")));

				// For Azure:   "ConnectionStrings:AzureSQLServerConnection"
				// For Windows: "Data:ForumDB:SQLServerConnection"
			}

			else
			{
				// Assuming SQLite is installed on all other operating systems
				services.AddDbContext<ApplicationDbContext>(options =>
						 options.UseSqlite(
							 Configuration.GetConnectionString("SQLiteConnection")));
			}

			services.AddIdentity<AppUser, IdentityRole>(opts =>
			{
				// user information validation options
				opts.User.RequireUniqueEmail = true;
				opts.User.AllowedUserNameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.@";

				// lockout options
				opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				opts.Lockout.MaxFailedAccessAttempts = 5;
				opts.Lockout.AllowedForNewUsers = true;

			}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI().AddDefaultTokenProviders().AddRoles<IdentityRole>();

			services.AddMvc().AddControllersAsServices();
			services.AddControllersWithViews();
			services.AddMvc().AddRazorOptions(options =>
			{
				options.PageViewLocationFormats
				 .Add("/Pages/shared/{0}.cshtml");
			});
			//AddRoles appended to configure services 
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});


				//Calls method from ApplicationDbContext.cs-creates Roles
			//ApplicationDbContext.CreateRoles(app.ApplicationServices, Configuration).Wait();
			//ApplicationDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();

		}

	}
}
