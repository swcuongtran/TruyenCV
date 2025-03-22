using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruyenCV.Domain.Entities;
using TruyenCV.Domain.Repositories;
using TruyenCV.Infrastructure.Data;

namespace TruyenCV.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly TruyenDbContext _context;

        public CommentRepository(TruyenDbContext context)
        {
            _context = context;
        }

        // ✅ Lấy danh sách bình luận có phân trang
        public async Task<IEnumerable<Comment>> GetCommentsByStoryIdPagedAsync(Guid storyId, int page, int pageSize)
        {
            return await _context.Comments
                .Where(c => c.StoryId == storyId)
                .OrderByDescending(c => c.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        // ✅ Thêm một bình luận mới (Trả về bool để báo trạng thái thành công/thất bại)
        public async Task<bool> AddCommentAsync(Comment comment)
        {
            try
            {
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi thêm bình luận: {ex.Message}");
                return false;
            }
        }

        // ✅ Xóa một bình luận (Trả về bool để kiểm tra thành công hay thất bại)
        public async Task<bool> DeleteCommentAsync(Guid id)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(id);
                if (comment != null)
                {
                    _context.Comments.Remove(comment);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi xóa bình luận: {ex.Message}");
                return false;
            }
        }

        // ✅ Đếm số bình luận của một truyện
        public async Task<int> CountCommentsByStoryIdAsync(Guid storyId)
        {
            return await _context.Comments
                .Where(c => c.StoryId == storyId)
                .CountAsync();
        }
    }
}
