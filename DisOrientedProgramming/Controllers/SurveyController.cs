using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using DisOrientedProgramming.Data;
using DisOrientedProgramming.Models;

namespace DisOrientedProgramming.Controllers
{
    public class SurveyController : Controller
    {

        private readonly ApplicationDbContext _context;
        private UserManager<AppUser> _userManager;
        

        public SurveyController (UserManager<AppUser> usrmgr, ApplicationDbContext context)
        {
            _context = context;
            _userManager = usrmgr;
        }

        private Task<AppUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: /<controller>/
        [HttpGet]
        public IActionResult TakeSurvey()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TakeSurvey(SurveyModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await GetCurrentUserAsync();

                model.SurveyModelId = new Guid();
                model.User = currentUser;


                _context.SurveyModels.Add(model);
                await _context.SaveChangesAsync();
            }

            int sumOfQ3Answers = 0;
            int sumOfQ4Answers = 0;
            int counter = 0;

            List<SurveyModel> listOfModelObjects = await _context.SurveyModels.ToListAsync();

            foreach (var obj in listOfModelObjects)
            {
                sumOfQ3Answers += obj.Question3;
                sumOfQ4Answers += obj.Question4;
                counter++;
            }

            ViewBag.averageValOfQ3s = sumOfQ3Answers / counter;
            ViewBag.averageValOfQ4s = sumOfQ4Answers / counter;

            //context.SurveyModels.Update(model);   // removed by KS -> you didn't change the model after adding it above, no need to update
            //context.SaveChanges();                // removed by KS -> no need to save changes that didn't happen

            return View(model);

            // Below is the original version of the contents of this method.
            // It totally wasts DB space by storing derivable data.

            //context.SurveyModels.Add(model);
            //context.SaveChanges();

            //List<SurveyModel> listOfModelObjects = context.SurveyModels.ToList();

            //foreach (var obj in listOfModelObjects)
            //{
            //    model.SumOfQ3Answers += obj.Question3;
            //    model.SumOfQ4Answers += obj.Question4;
            //    model.TotalNumOfQ3s++;
            //    model.TotalNumOfQ4s++;
            //}

            //model.AverageValOfQ3s = model.SumOfQ3Answers / model.TotalNumOfQ3s;
            //model.AverageValOfQ4s = model.SumOfQ4Answers / model.TotalNumOfQ4s;

            //context.SurveyModels.Update(model);
            //context.SaveChanges();

            //return View(model);
        }



    }//End Class 
}//End Namespace 
