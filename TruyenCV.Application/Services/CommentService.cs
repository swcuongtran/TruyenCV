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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        // ✅ Lấy danh sách bình luận có phân trang (Mặc định mỗi trang có 10 bình luận)
        public async Task<IEnumerable<CommentDto>> GetCommentsByStoryIdPagedAsync(Guid storyId, int page = 1, int pageSize = 10)
        {
            var comments = await _commentRepository.GetCommentsByStoryIdPagedAsync(storyId, page, pageSize);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        // ✅ Thêm bình luận mới
        public async Task<bool> AddCommentAsync(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            return await _commentRepository.AddCommentAsync(comment);
        }

        // ✅ Xóa bình luận
        public async Task<bool> DeleteCommentAsync(Guid commentId)
        {
            return await _commentRepository.DeleteCommentAsync(commentId);
        }

        // ✅ Đếm số lượng bình luận của một truyện
        public async Task<int> CountCommentsByStoryIdAsync(Guid storyId)
        {
            return await _commentRepository.CountCommentsByStoryIdAsync(storyId);
        }
    }
}
