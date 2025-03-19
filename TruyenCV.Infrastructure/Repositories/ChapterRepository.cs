using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruyenCV.Domain.Entities;
using TruyenCV.Domain.Repositories;
using TruyenCV.Infrastructure.Data;

namespace TruyenCV.Infrastructure.Repositories
{
    public class ChapterRepository : IChapterRepositoy
    {
        private readonly TruyenDbContext _context;

        public ChapterRepository(TruyenDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách chương theo storyId
        public async Task<IEnumerable<Chapter>> GetChaptersAsync(Guid storyId)
        {
            return await _context.Chapters
                .Where(c => c.StoryId == storyId)
                .OrderBy(c => c.ChapterNumber)
                .ToListAsync();
        }

        // Lấy chi tiết một chương theo ID
        public async Task<Chapter> GetChapterByIdAsync(Guid chapterId)
        {
            return await _context.Chapters.FindAsync(chapterId);
        }

        // Tạo một chương mới
        public async Task<Chapter> CreateChapterAsync(Chapter chapter)
        {
            await _context.Chapters.AddAsync(chapter);
            await _context.SaveChangesAsync();
            return chapter;
        }

        // Cập nhật một chương
        public async Task UpdateChapterAsync(Guid chapterId, Chapter chapter)
        {
            var existingChapter = await _context.Chapters.FindAsync(chapterId);
            if (existingChapter != null)
            {
                existingChapter.Title = chapter.Title;
                existingChapter.Content = chapter.Content;
                existingChapter.ChapterNumber = chapter.ChapterNumber;

                _context.Chapters.Update(existingChapter);
                await _context.SaveChangesAsync();
            }
        }

        // Xóa một chương
        public async Task DeleteChapterAsync(Guid chapterId)
        {
            var chapter = await _context.Chapters.FindAsync(chapterId);
            if (chapter != null)
            {
                _context.Chapters.Remove(chapter);
                await _context.SaveChangesAsync();
            }
        }
    }
}
