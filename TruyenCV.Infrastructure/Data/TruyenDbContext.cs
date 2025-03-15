using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Domain.Entities;

namespace TruyenCV.Infrastructure.Data
{
    public class TruyenDbContext:DbContext
    {
        public TruyenDbContext(DbContextOptions<TruyenDbContext> options) : base(options)
        {
        }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>().HasKey(x => x.StoryId);
            modelBuilder.Entity<Chapter>().HasKey(x => x.ChapterId);
            modelBuilder.Entity<Comment>().HasKey(x => x.CommentId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Story>()
                .HasMany(s => s.Chapters)
                .WithOne(c => c.Story)
                .HasForeignKey(c => c.StoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Story)
                .WithMany(s => s.Comments)
                .HasForeignKey(c => c.StoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
