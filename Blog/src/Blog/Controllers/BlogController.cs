using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Context;
using Microsoft.AspNet.Mvc;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        protected BlogContext Context;
        public BlogController(BlogContext context)
        {
            Context = context;
        }
    }
}
