using System.Collections;
using System.Collections.Generic;

namespace Blog.Data.Entities {
    public class Tag {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PostTag> TagPosts { get; set; }
    }
}