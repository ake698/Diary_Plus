using Diary.Entity.ModelBuilds;
using Microsoft.EntityFrameworkCore;

namespace Diary.Entity
{
    public class DiaryContext : DbContext
    {
        public DiaryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            new DiaryBuilder(builder);
            new CommentBuilder(builder);
        }

        public DbSet<DiaryEntity> Diaries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
