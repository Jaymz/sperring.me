using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Blog.Data.Context;
using Blog.Data.Entities;
using Blog.ViewModels.Posts;

namespace Blog.Controllers
{
    public class PostsController : BlogController
    {
        // GET: Posts
        public PostsController(BlogContext context) : base(context) {}

        public IActionResult Index()
        {
            return View(Context.Posts.Select(p => new PostViewModel() {
                PrettyUrl = p.PrettyUrl,
                PublishDate = p.CreatedTime,
                UpdatedDate = p.UpdatedTime,
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
            var postVm = new PostViewModel();
            postVm.Id = post.Id;
            postVm.PrettyUrl = post.PrettyUrl;
            postVm.Title = post.Title;
            postVm.Author = post.Author.FirstName + " " + post.Author.LastName;
            postVm.PublishDate = post.CreatedTime;
            //postVm.Tags = String.Join(", ", post.Tags);

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
        public IActionResult Create(PostViewModel postVm)
        {
            if (ModelState.IsValid) {
                var post = new Post();
                post.Id = postVm.Id;
                post.PrettyUrl = postVm.PrettyUrl;
                post.Title = postVm.Title;
                post.Author = Context.Authors.Single(a => a.FirstName == post.Author.FirstName && a.LastName == post.Author.LastName);
                post.CreatedTime = postVm.PublishDate;
                //post.Tags = postVm.Tags.Split(new [] { ", " }, StringSplitOptions.None).Select(s => Context.Tags.Single(t => t.Name == s)).ToList();

                post.CreatedTime = DateTime.Now;
                post.UpdatedTime = DateTime.Now;

                Context.Posts.Add(post);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postVm);
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
            var postVm = new PostViewModel();
            postVm.Id = post.Id;
            postVm.PrettyUrl = post.PrettyUrl;
            postVm.Title = post.Title;
            postVm.Author = post.Author?.FirstName + " " + post.Author?.LastName;
            postVm.PublishDate = post.CreatedTime;
            postVm.Content = post.Content;
            //if (post.Tags != null)
            //    postVm.Tags = String.Join(", ", post.Tags);

            return View(postVm);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostViewModel postVm)
        {
            if (ModelState.IsValid) {
                if (postVm.PublishDate <= DateTime.MinValue)
                    postVm.PublishDate = DateTime.Now;

                postVm.UpdatedDate = DateTime.Now;

                var post = Context.Posts.Single(p => p.Id == postVm.Id);
                post.CreatedTime = postVm.PublishDate;
                post.UpdatedTime = postVm.UpdatedDate;
                if (!String.IsNullOrEmpty(postVm.Author))
                    post.Author = Context.Authors.Single(a => a.FirstName + " " + a.LastName == postVm.Author);
                post.PrettyUrl = postVm.PrettyUrl;

                //post.Tags = new List<Tag>();

                foreach (var tag in postVm.Tags.Split(new[] {", "}, StringSplitOptions.None)) {
                    var dbTag = Context.Tags.SingleOrDefault(t => t.Name == tag) ?? new Tag() {Name = tag};

                    //post.Tags.Add(dbTag);
                }
                //post.Tags =
                //    postVm.Tags.Split(new[] {", "}, StringSplitOptions.None)
                //        .Select(s => Context.Tags.Single(t => t.Name == s))
                //        .ToList();
                post.Title = postVm.Title;
                post.Content = postVm.Content;

                Context.Update(post);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postVm);
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
