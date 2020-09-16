using AutoMapper;
using Diary.Bussiness.Dtos.Comment;
using Diary.Entity;
using Diary.IBLL;
using Diary.IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.BLL
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly IDiaryRepository _diaryRepository;
        private readonly ICurrentUser _currentUser;

        public CommentService(IMapper mapper, ICommentRepository commentRepository, IDiaryRepository diaryRepository, ICurrentUser currentUser)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _diaryRepository = diaryRepository;
            _currentUser = currentUser;
        }

        public async Task<CommentDto> CreateAsync(CreateOrUpdateCommentDto input)
        {
            await _diaryRepository.GetAsync(input.DiaryId);
            var currentUser = _currentUser.GetCurrentUser();

            var comment = new Comment()
            {
                Content = input.Content,
                DiaryId = input.DiaryId,
                CreateId = currentUser.Id,
            };
            var result = await _commentRepository.CreateAsync(comment);
            return _mapper.Map<CommentDto>(result);
        }

        public async Task<CommentDto> DeleteAsync(Guid id)
        {
            var result = await _commentRepository.DeleteAsync(id);
            return _mapper.Map<CommentDto>(result);
        }

        public async Task<CommentDto> GetAsync(Guid id)
        {
            var result = await _commentRepository.GetAsync(id);
            return _mapper.Map<CommentDto>(result);
        }

        public Task<List<CommentDto>> GetListAsync()
        {
            // 此方法不需要
            throw new NotImplementedException();
        }

        public async Task<List<CommentDto>> GetListAsync(Guid id)
        {
            var result = await _commentRepository.GetAllAsync()
                            .Where(x => x.DiaryId == id)
                            .ToListAsync();
            return _mapper.Map<List<CommentDto>>(result);
        }

        public Task<CommentDto> UpdateAsync(Guid id, CreateOrUpdateCommentDto input)
        {
            // 暂时不需要
            throw new NotImplementedException();
        }
    }
}
