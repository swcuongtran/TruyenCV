using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Domain.Entities;

namespace TruyenCV.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsByStoryIdAsync(Guid storyId);
        Task AddCommentAsync(Comment comment);
        Task DeleteCommentAsync(Guid id);
        Task<int> CountCommentsByStoryIdAsync(Guid storyId);
        Task<IEnumerable<Comment>> GetCommentsByStoryIdPagedAsync(Guid storyId, int page, int pageSize); // 🔹 Lấy bình luận có phân trang
    }
}
