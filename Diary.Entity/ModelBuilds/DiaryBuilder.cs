using Microsoft.EntityFrameworkCore;

namespace Diary.Entity.ModelBuilds
{
    public class DiaryBuilder
    {
        public DiaryBuilder(ModelBuilder builder)
        {
            var diary = builder.Entity<DiaryEntity>();
            diary.HasKey(p => p.Id);

            diary.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            diary.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
