using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Context;
using Blog.Utils;
using Blog.ViewModels.Posts;
using Microsoft.AspNet.Mvc;

namespace Blog.Controllers
{
    public class HomeController : BlogController
    {
        public HomeController(BlogContext context) : base(context) {}

        public IActionResult Index()
        {
            var postList = new List<PostViewModel>();
            var markdown = new Markdown();
            var posts = Context.Posts.OrderByDescending(p => p.CreatedTime);
            foreach (var post in posts)
            {
                postList.Add(new PostViewModel()
                {
                    //Author = post.Author.FirstName + " " + post.Author.LastName,
                    Content = markdown.Transform(post.Content),
                    Title = post.Title,
                    PublishDate = post.CreatedTime,
                    PrettyUrl = post.PrettyUrl
                });
            }
            return View(postList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
