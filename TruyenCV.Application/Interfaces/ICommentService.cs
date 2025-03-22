using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Application.DTOs;

namespace TruyenCV.Application.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetCommentsByStoryIdPagedAsync(Guid storyId, int page = 1, int pageSize = 10); // Lấy danh sách bình luận có phân trang
        Task<bool> AddCommentAsync(CommentDto commentDto); // Thêm bình luận mới
        Task<bool> DeleteCommentAsync(Guid commentId); // Xóa bình luận
        Task<int> CountCommentsByStoryIdAsync(Guid storyId); // Đếm số lượng bình luận của truyện
    }
}
