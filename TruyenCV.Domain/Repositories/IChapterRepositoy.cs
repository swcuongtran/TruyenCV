using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Domain.Entities;

namespace TruyenCV.Domain.Repositories
{
    public interface IChapterRepositoy
    {
        Task<IEnumerable<Chapter>> GetChaptersAsync(Guid storyId);
        Task<Chapter> GetChapterByIdAsync(Guid chapterId);
        Task<Chapter> CreateChapterAsync(Chapter chapter);
        Task UpdateChapterAsync(Guid chapterId, Chapter chapter);
        Task DeleteChapterAsync(Guid chapterId);
    }
}
