using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
