using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisOrientedProgramming.Controllers
{
    public class ResourcesController : Controller
    {
        public IActionResult Index()
        {
            List<Resources> resources = ResourceRepository.Resources;
            books.Sort(r1, r2);
            return View(Resources);
        }
        
        /*public IActionResult LinkList()
        {
            List<Link> links = LinkRepository.Links;
            links.Sorts(l1, l2) 
        */
        }
    }

