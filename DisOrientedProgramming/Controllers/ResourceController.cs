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
    public class ResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<ResourceLink> resources = await _context.ResourceLinks.OrderBy(r => r.ResourceType).ThenBy(r => r.ResourceName).ToListAsync();
            return View(resources);
        }
        
        /*public IActionResult LinkList()
        {
            List<Link> links = LinkRepository.Links;
            links.Sorts(l1, l2) 
        */
        }
    }

