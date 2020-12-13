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

            int     sumOfQ3Answers  = 0;
            int     sumOfQ4Answers  = 0;
            int     totalNumOfQ3s   = 0;
            int     totalNumOfQ4s   = 0;
            double  averageValOfQ3s = 0;
            double  averageValOfQ4s = 0;

            foreach (var obj in listOfModelObjects)
            {
                sumOfQ3Answers += obj.Question3;
                sumOfQ4Answers += obj.Question4;
                totalNumOfQ3s++;
                totalNumOfQ4s++;
            }

            averageValOfQ3s = sumOfQ3Answers / totalNumOfQ3s;
            averageValOfQ4s = sumOfQ4Answers / totalNumOfQ4s;

            context.SurveyModels.Add(model);
            context.SaveChanges();

            return View(model);
        }



    }//End Class 
}//End Namespace 
