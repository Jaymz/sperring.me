using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Blog.Data.Context;
using Blog.Data.Entities;

namespace Blog.Controllers
{
    public class PostsController : BlogController
    {
        // GET: Posts
        public PostsController(BlogContext context) : base(context) {}

        public IActionResult Index()
        {
            return View(Context.Posts.Select(p => new Post() {
                PrettyUrl = p.PrettyUrl,
                CreatedTime = p.CreatedTime,
                Content = p.Content.Substring(0, 100) + "...",
                Title = p.Title,
                Id = p.Id,
            }).ToList());
        }

        // GET: Posts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Post post = Context.Posts.Single(m => m.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                Context.Posts.Add(post);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Post post = Context.Posts.Single(m => m.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                Context.Update(post);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Post post = Context.Posts.Single(m => m.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Post post = Context.Posts.Single(m => m.Id == id);
            Context.Posts.Remove(post);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
