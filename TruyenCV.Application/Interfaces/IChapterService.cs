using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Application.DTOs;

namespace TruyenCV.Application.Interfaces
{
    public interface IChapterService
    {
        Task<IEnumerable<ChapterDto>> GetChaptersByStoryIdAsync(Guid storyId);
        Task<ChapterDto> GetChapterByIdAsync(Guid chapterId); 
        Task<ChapterDto?> CreateChapterAsync(CreateChapterDto chapterDto);
        Task<bool> UpdateChapterAsync(Guid chapterId, UpdateChapterDto chapterDto);
        Task<bool> DeleteChapterAsync(Guid chapterId); 
    }
}
