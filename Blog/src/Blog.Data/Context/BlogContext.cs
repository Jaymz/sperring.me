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

        public DbSet<Post> Posts { get; set; }
        public DbSet<Status> PostStatus { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Post>().HasOne(t => t.Author);

            base.OnModelCreating(builder);
        }
    }
}
