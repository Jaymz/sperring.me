using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;

namespace Blog.Data.Context
{
    public class BlogContext : IdentityDbContext<Author>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var config = new ConfigurationBuilder().Build();
            var defaultConnection = config["Data:DefaultConnection:ConnectionString"];
            optionsBuilder.UseSqlServer(defaultConnection);
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
