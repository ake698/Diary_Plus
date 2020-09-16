using AutoMapper;
using Diary.Bussiness.Dtos.Comment;
using Diary.Entity;

namespace Diary.BLL.Mappers.CommentMapper
{
    public class CommentProfiles : Profile
    {
        public CommentProfiles()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}
