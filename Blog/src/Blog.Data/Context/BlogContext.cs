using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Blog.Data.Context
{
    public class BlogContext : IdentityDbContext<Author>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLExpress;Database=BlogIdentities;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Status> PostStatus { get; set; }
        public DbSet<Tag> Tags { get; set; }    
    }
}
