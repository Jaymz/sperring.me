using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Data.Entities {
    public class Author : IdentityUser {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastLogin { get; set; }
    }
}