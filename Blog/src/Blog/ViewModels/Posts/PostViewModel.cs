using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Entities;

namespace Blog.ViewModels.Posts
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Author { get; set; }
        public string PrettyUrl { get; set; }
        public string Tags { get; set; } 
    }
}
