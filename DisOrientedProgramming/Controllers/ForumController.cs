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
    public class ForumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Topics = _context.ForumTopics.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(ForumPost usersPost)
        {
            ForumTopic topic = _context.ForumTopics.Where(f =>f.Name == usersPost.Topic.Name).FirstOrDefault();

            usersPost.Topic = topic;

            _context.ForumPosts.Add(usersPost);
            _context.SaveChanges();

            return RedirectToAction("Topic", new { t = usersPost.Topic.ForumTopicId, Area = "" });

        }

        public IActionResult Topic(Guid t)
        {
            ForumTopic topic = _context.ForumTopics.First(Topic => Topic.ForumTopicId == t);
            ViewBag.Topic = topic.Name;
            ViewBag.Posts = _context.ForumPosts.Where(post => post.Topic == topic).ToList();
            return View();
        }


        public async Task<IActionResult> ViewThread(Guid startPost) // thread head
        {
            // only the posts that go in this thread
            var postList = await _context.ForumPosts.Where(post => post.ParentPost.ForumPostId == startPost).ToListAsync();

            //TODO: That :
            // then display posts and lists like a tree/graph wee!!!

            return null;
        }
    }
}
