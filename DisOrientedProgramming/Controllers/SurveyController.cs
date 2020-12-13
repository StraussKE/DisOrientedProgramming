using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using DisOrientedProgramming.Data;
using DisOrientedProgramming.Models;

namespace DisOrientedProgramming.Controllers
{
    public class SurveyController : Controller
    {

        ApplicationDbContext context;

        public SurveyController (ApplicationDbContext c)
        {
            context = c;
        }

        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SurveyModel model)
        {
            List<SurveyModel> listOfModelObjects = context.SurveyModels.ToList();

            int sumOfQ3Vals = 0;
            int sumOfQ4Vals = 0;

            foreach (var obj in listOfModelObjects)
            {
                sumOfQ3Vals += obj.Question3;
                sumOfQ4Vals += obj.Question4;
            }

            context.SurveyModels.Add(model);
            context.SaveChanges();

            return View(model);
        }



    }//End Class 
}//End Namespace 
