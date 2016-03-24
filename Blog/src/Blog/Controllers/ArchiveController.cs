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
    public class ArchiveController : Controller
    {
        public IActionResult PrettyUrl(string prettyUrl) {
            using (var db = new BlogContext()) {
                var markdown = new Markdown();
                var post = db.Posts.SingleOrDefault(p => p.PrettyUrl == prettyUrl);
                if (post != null)
                    return View("Index", new PostViewModel {
                        Content = markdown.Transform(post.Content),
                        Title = post.Title,
                        PrettyUrl = post.PrettyUrl,
                        PublishDate = post.CreatedTime
                    });

                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult PostDate(string postDate) {
            return View();
        }
    }
}
