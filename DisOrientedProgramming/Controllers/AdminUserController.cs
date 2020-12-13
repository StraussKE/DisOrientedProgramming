using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using DisOrientedProgramming.Data;
using DisOrientedProgramming.Models;



namespace DisOrientedProgramming.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminUserController : Controller
    {
        private UserManager<AppUser> _userManager;
        private IUserValidator<AppUser> _userValidator;
        private IPasswordValidator<AppUser> _passwordValidator;
        private IPasswordHasher<AppUser> _passwordHasher;
        private ApplicationDbContext _context;
        private RoleManager<IdentityRole> _roleManager;
        
        public AdminUserController(UserManager<AppUser> usrMgr,
                IUserValidator<AppUser> userValid,
                IPasswordValidator<AppUser> passValid,
                IPasswordHasher<AppUser> passwordHash,
                ApplicationDbContext context, 
                RoleManager<IdentityRole> roleMgr)
      
        {
            _userManager=usrMgr;
            _userValidator=userValid;
            _passwordValidator=passValid;
            _passwordHasher=passwordHash;
            _context = context;
            _roleManager = roleMgr;
        }

        public async Task<ViewResult> Index(string orderBy = "default")
        {
            //gets the data 
            var users = await _userManager.Users.ToListAsync();
            List<UserRoleViewModel> userRoles = new List<UserRoleViewModel>();
            foreach (AppUser user in users)
            {
                UserRoleViewModel vm = new UserRoleViewModel();
                vm.Id = user.Id;
                vm.FirstName = user.FirstName;
                vm.LastName = user.LastName;
                vm.Email = user.Email;
                vm.UserName = user.UserName;
                var roles = await _userManager.GetRolesAsync(user);
                vm.Role = String.Join(",", roles);
                userRoles.Add(vm);
            }
            //Sorts columns in admin user manager
            ViewBag.orderBy = orderBy;
            if (orderBy == "firstname")
            {
                return View(userRoles.OrderBy(u => u.FirstName));
            }
            else if (orderBy == "revfirstname")
            {
                return View(userRoles.OrderByDescending(u => u.FirstName));
            }
            else if (orderBy == "lastname")
            {
                return View(userRoles.OrderBy(u => u.LastName));
            }
            else if (orderBy == "revlastname")
            {
                return View(userRoles.OrderByDescending(u => u.LastName));
            }
            else if (orderBy == "username")
            {
                return View(userRoles.OrderBy(u => u.UserName));
            }
            else if (orderBy == "revusername")
            {
                return View(userRoles.OrderByDescending(u => u.UserName));
            }
            else if (orderBy == "email")
            {
                return View(userRoles.OrderBy(u => u.Email));
            }
            else if (orderBy == "revemail")
            {
                return View(userRoles.OrderByDescending(u => u.Email));
            }
            else if (orderBy == "revrole")
            {
                return View(userRoles.OrderByDescending(u => u.Role));

            }
            else if (orderBy == "role")
            {
                return View(userRoles.OrderByDescending(u => u.Role));
            }
            else if (orderBy == "revdefault")
            {
                return View(userRoles.OrderByDescending(u => u.FirstName));
            }
            else
            {
                return View(userRoles.OrderBy(u => u.FirstName));
            }
           
        }
         

        public ViewResult Create() => View();
        public ViewResult ShowAccounts()

        {
            return View(_userManager.Users);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {         
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName=model.UserName,
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    Email=model.Email,
                    CreatedAccount = DateTime.Now
                };
                IdentityResult result = null;
                try
                {
                    result=await _userManager.CreateAsync(user, model.Password);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user!=null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", _userManager.Users);
        }
        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user!= null)
            {
               return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string firstName, string lastName, string email,
              string password)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail = await _userValidator.ValidateAsync(_userManager, user);

                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await _passwordValidator.ValidateAsync(_userManager,
                        user, password);

                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null)
                        || (validEmail.Succeeded
                        && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View(user);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
               ModelState.AddModelError("", error.Description);
            }
        }

   
    }
}