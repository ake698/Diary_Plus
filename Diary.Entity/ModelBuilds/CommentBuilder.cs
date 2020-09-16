using Microsoft.EntityFrameworkCore;

namespace Diary.Entity.ModelBuilds
{
    public class CommentBuilder
    {
        public CommentBuilder(ModelBuilder builder)
        {
            var commentBuilder = builder.Entity<Comment>();

            commentBuilder.HasKey(p => p.Id);

            commentBuilder
                .HasOne(p => p.Creater)
                .WithMany()
                .HasForeignKey(p => p.CreateId)
                .OnDelete(DeleteBehavior.NoAction);

            commentBuilder
                .HasOne(p => p.Diary)
                .WithMany()
                .HasForeignKey(p => p.CreateId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
