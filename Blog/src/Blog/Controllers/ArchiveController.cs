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
    public class ArchiveController : BlogController
    {
        public ArchiveController(BlogContext context) : base(context) {}

        public IActionResult PrettyUrl(string prettyUrl) {
            var markdown = new Markdown();
            var post = Context.Posts.SingleOrDefault(p => p.PrettyUrl == prettyUrl);
            if (post != null)
                return View("Index", new PostViewModel {
                    Content = markdown.Transform(post.Content),
                    Title = post.Title,
                    PrettyUrl = post.PrettyUrl,
                    PublishDate = post.CreatedTime
                });

            return RedirectToAction("Index", "Home");
        }

        public IActionResult PostDate(string postDate) {
            return View();
        }
    }
}
