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
    public class ResourceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.MentalHealth = await _context.ResourceLinks.OrderBy(r => r.ResourceType).ThenBy(r => r.ResourceName).Where(r => r.ResourceType == "Mental Wellness").ToListAsync();

            ViewBag.PhysicalHealth = await _context.ResourceLinks.OrderBy(r => r.ResourceType).ThenBy(r => r.ResourceName).Where(r => r.ResourceType == "Physical Wellness").ToListAsync();

            ViewBag.ResourceTypes =  _context.ResourceLinks.OrderBy(r => r.ResourceType).ThenBy(r => r.ResourceName).Where(r => r.ResourceType == "Physical Wellness").ToListAsync();

            return View();
        }
        public  async Task<IActionResult> Create(ResourceLink model)
        {
            //if (ModelState.IsValid)
            //{

                //    ResourceLink resource = new ResourceLink
                //    {
                //        ResourceLinkId = Guid.NewGuid(),
                //        ResourceName = model.ResourceName,
                //        ResourceType = model.ResourceType,
                //    };
                model.ResourceLinkId = Guid.NewGuid();
                _context.ResourceLinks.Add(model);
                await _context.SaveChangesAsync();

                //await _context.SaveChangesAsync().ConfigureAwait(true);
                return RedirectToAction("Index", new { id = model.ResourceLinkId });
            //}

           // return View();

        }
    }
}


   

    


