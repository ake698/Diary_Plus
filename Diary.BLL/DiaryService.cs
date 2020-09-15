using AutoMapper;
using Diary.Bussiness.Dtos.Diary;
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
    public class DiaryService : IDiaryService
    {
        private readonly IMapper _mapper;
        private readonly IDiaryRepository _diaryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrentUser _currentUser;

        public DiaryService(IMapper mapper, IDiaryRepository diaryRepository, ICategoryRepository categoryrepository, ICurrentUser currentUser)
        {
            _mapper = mapper;
            _diaryRepository = diaryRepository;
            _categoryRepository = categoryrepository;
            _currentUser = currentUser;
        }

        public async Task<DiaryDto> CreateAsync(CreateOrUpdateDiaryDto input)
        {
            // 用于检测是否存在目录
            var category = await _categoryRepository.GetAsync(input.CategoryId);

            var diaryEntity = _mapper.Map<DiaryEntity>(input);
            diaryEntity.UserId = _currentUser.GetCurrentUser().Id;
            var result = await _diaryRepository.CreateAsync(diaryEntity);
            return _mapper.Map<DiaryDto>(result);
        }

        public async Task<DiaryDto> DeleteAsync(Guid id)
        {
            return _mapper.Map<DiaryDto>(await _diaryRepository.DeleteAsync(id));
        }

        public async Task<DiaryDto> GetAsync(Guid id)
        {
            var result = await _diaryRepository.GetAllAsync()
                .Where(x => x.Id == id)
                .Include(x => x.Category)
                .Include(p => p.User)
                .FirstAsync();
            if (result == null) throw new ArgumentNullException($"There is no Diary Entity with id = {id}");
            return _mapper.Map<DiaryDto>(result);
        }

        public async Task<List<DiaryDto>> GetListAsync()
        {
            var result = await _diaryRepository.GetAllAsync()
                .Include(x => x.Category)
                .Include(x => x.User)
                .ToListAsync();
            return _mapper.Map<List<DiaryDto>>(result);
        }

        public async Task<DiaryDto> UpdateAsync(Guid id, CreateOrUpdateDiaryDto input)
        {
            // 用于检测是否存在目录
            var category = await _categoryRepository.GetAsync(input.CategoryId);

            var diary = await _diaryRepository.GetAsync(id);
            diary.Title = input.Title;
            diary.Content = input.Content;
            diary.CategoryId = input.CategoryId;
            diary.IsPublic = input.IsPublic;

            var result = await _diaryRepository.UpdateAsync(diary);
            return _mapper.Map<DiaryDto>(result);
        }
    }
}
