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
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepositoy _chapterRepository;
        private readonly IMapper _mapper;

        public ChapterService(IChapterRepositoy chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }

        // ✅ Lấy danh sách chương của truyện
        public async Task<IEnumerable<ChapterDto>> GetChaptersByStoryIdAsync(Guid storyId)
        {
            var chapters = await _chapterRepository.GetChaptersAsync(storyId);
            return _mapper.Map<IEnumerable<ChapterDto>>(chapters);
        }

        // ✅ Lấy chương theo ID
        public async Task<ChapterDto> GetChapterByIdAsync(Guid chapterId)
        {
            var chapter = await _chapterRepository.GetChapterByIdAsync(chapterId);
            return chapter != null ? _mapper.Map<ChapterDto>(chapter) : null;
        }

        // ✅ Tạo chương mới
        public async Task<ChapterDto?> CreateChapterAsync(CreateChapterDto chapterDto)
        {
            var chapter = _mapper.Map<Chapter>(chapterDto);
            chapter.ChapterId = Guid.NewGuid(); // ✅ Đảm bảo có ID khi tạo mới

            var createdChapter = await _chapterRepository.CreateChapterAsync(chapter);
            return createdChapter != null ? _mapper.Map<ChapterDto>(createdChapter) : null;
        }

        // ✅ Cập nhật chương
        public async Task<bool> UpdateChapterAsync(Guid chapterId, UpdateChapterDto chapterDto)
        {
            var chapter = _mapper.Map<Chapter>(chapterDto);
            await _chapterRepository.UpdateChapterAsync(chapterId, chapter);
            return true;
        }

        // ✅ Xóa chương
        public async Task<bool> DeleteChapterAsync(Guid chapterId)
        {
            await _chapterRepository.DeleteChapterAsync(chapterId);
            return true;
        }
    }
}
