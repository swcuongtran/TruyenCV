using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TruyenCV.Application.DTOs;
using TruyenCV.Application.Interfaces;
using TruyenCV.Domain.Entities;
using TruyenCV.Domain.Repositories;

namespace TruyenCV.Application.Services
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;

        public StoryService(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }

        // ✅ Lấy danh sách truyện (Trả về DTO)
        public async Task<IEnumerable<StoryDto>> GetStoriesAsync()
        {
            var stories = await _storyRepository.GetStoriesAsync();
            return _mapper.Map<IEnumerable<StoryDto>>(stories);
        }

        // ✅ Lấy truyện theo ID (Tăng ViewCount khi người dùng xem)
        public async Task<StoryDto> GetStoryByIdAsync(Guid storyId)
        {
            var story = await _storyRepository.GetStoryByIdAsync(storyId);
            if (story == null) return null;

            await _storyRepository.IncrementViewCountAsync(storyId); // 👈 Tăng ViewCount khi truyện được đọc
            return _mapper.Map<StoryDto>(story);
        }

        // ✅ Tạo truyện mới
        public async Task<bool> CreateStoryAsync(StoryDto storyDto)
        {
            var story = _mapper.Map<Story>(storyDto);
            return await _storyRepository.CreateStoryAsync(story) != null;
        }

        // ✅ Cập nhật truyện
        public async Task<bool> UpdateStoryAsync(Guid storyId, StoryDto storyDto)
        {
            var story = _mapper.Map<Story>(storyDto);
            await _storyRepository.UpdateStoryAsync(storyId, story);
            return true;
        }

        // ✅ Xóa truyện
        public async Task<bool> DeleteStoryAsync(Guid storyId)
        {
            await _storyRepository.DeleteStoryAsync(storyId);
            return true;
        }

        // ✅ Tăng lượt xem
        public async Task IncreaseViewCountAsync(Guid storyId)
        {
            await _storyRepository.IncrementViewCountAsync(storyId);
        }
    }
}
