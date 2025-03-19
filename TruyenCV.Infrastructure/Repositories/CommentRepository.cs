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

        // Lấy danh sách bình luận của một truyện
        public async Task<IEnumerable<Comment>> GetCommentsByStoryIdAsync(Guid storyId)
        {
            return await _context.Comments
                .Where(c => c.StoryId == storyId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        // Thêm một bình luận mới
        public async Task AddCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        // Xóa một bình luận
        public async Task DeleteCommentAsync(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        // Đếm số bình luận của một truyện
        public async Task<int> CountCommentsByStoryIdAsync(Guid storyId)
        {
            return await _context.Comments
                .Where(c => c.StoryId == storyId)
                .CountAsync();
        }

        // Lấy danh sách bình luận có phân trang
        public async Task<IEnumerable<Comment>> GetCommentsByStoryIdPagedAsync(Guid storyId, int page, int pageSize)
        {
            return await _context.Comments
                .Where(c => c.StoryId == storyId)
                .OrderByDescending(c => c.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
