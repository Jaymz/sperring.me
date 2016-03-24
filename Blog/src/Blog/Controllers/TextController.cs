using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Utils;
using Microsoft.AspNet.Mvc;

namespace Blog.Controllers
{
    public class TextController : Controller
    {
        public string GetMarkdownPreview(string markdown) {
            var md = new Markdown();
            return md.Transform(markdown);
        }
    }
}
