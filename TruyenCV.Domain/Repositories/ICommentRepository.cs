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
        Task<bool> AddCommentAsync(Comment comment);
        Task<bool> DeleteCommentAsync(Guid id);
        Task<int> CountCommentsByStoryIdAsync(Guid storyId);
        Task<IEnumerable<Comment>> GetCommentsByStoryIdPagedAsync(Guid storyId, int page, int pageSize); 
    }
}
