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
    public class ForumController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<AppUser> _userManager;


        public ForumController(UserManager<AppUser> usrmgr, ApplicationDbContext context)
        {
            _context = context;
            _userManager = usrmgr;
        }

        private Task<AppUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            ViewBag.Topics = await _context.ForumTopics.OrderBy(t => t.OrderNumber).ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ForumPost usersPost)
        {
            if (ModelState.IsValid)
            {
                ForumTopic topic = await _context.ForumTopics.Where(f => f.Name == usersPost.Topic.Name).FirstOrDefaultAsync();
                var currentUser = await GetCurrentUserAsync();

                usersPost.User = currentUser;
                usersPost.Topic = topic;

                usersPost.TimePosted = DateTime.Now;

                _context.ForumPosts.Add(usersPost);
                await _context.SaveChangesAsync();

                return RedirectToAction("Topic", new { t = usersPost.Topic.ForumTopicId, Area = "" });
            }
            return View("usersPost");

        }

        public IActionResult Topic(Guid t)
        {
            ForumTopic topic =  _context.ForumTopics.First(Topic => Topic.ForumTopicId == t);
            ViewBag.Topic = topic.Name;
            ViewBag.Posts = _context.ForumPosts.Where(post => post.Topic == topic && post.ParentPost == null).ToList();
            return View();
        }



        //I do not know how to implement this
        //will come back and learn async when time
       
        /* public async Task<IActionResult> ViewThread(Guid startPost) // thread head
        {
            // only the posts that go in this thread
            var postList = await _context.ForumPosts.Where(post => post.ParentPost.ForumPostId == startPost).ToListAsync();

            //TODO: That :
            // then display posts and lists like a tree/graph wee!!!

            return null;
        }*/

        public IActionResult ViewThread(Guid startPost)
        {
            ViewBag.TopPost = _context.ForumPosts.Where(p =>
            p.ForumPostId == startPost).FirstOrDefault(); ;

            ViewBag.PostList = _context.ForumPosts.Where(p =>
            p.ParentPost.ForumPostId == startPost).ToList();
            
            //make the base post
            ForumPost post = new ForumPost();
            //make the parent holder
            ForumPost topPost = new ForumPost();

            
            //set place holders
            post.ParentPost = topPost;
            

           
            return View(post);
        }
        
        //handels the submition of commints
        [HttpPost]
        public IActionResult ViewThread(ForumPost comment)
        {
            //get the parent post
            comment.ParentPost = _context.ForumPosts.Where(p =>
            p.ForumPostId == comment.ParentPost.ForumPostId).FirstOrDefault();

            //set the post time 
            comment.TimePosted = DateTime.Now;

            comment.ForumPostId = Guid.NewGuid();

            _context.ForumPosts.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("ViewThread", new { startPost = comment.ParentPost.ForumPostId, Area = "" });
        }
    }
}
