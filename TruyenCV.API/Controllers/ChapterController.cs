using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruyenCV.Application.DTOs;
using TruyenCV.Application.Interfaces;

namespace TruyenCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterService _chapterService;

        public ChapterController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        // ✅ Lấy danh sách chương của một truyện
        [HttpGet("story/{storyId}")]
        public async Task<IActionResult> GetChaptersByStory(Guid storyId)
        {
            var chapters = await _chapterService.GetChaptersByStoryIdAsync(storyId);
            return Ok(chapters);
        }

        // ✅ Lấy thông tin một chương theo ID
        [HttpGet("{chapterId}")]
        public async Task<IActionResult> GetChapterById(Guid chapterId)
        {
            var chapter = await _chapterService.GetChapterByIdAsync(chapterId);
            if (chapter == null) return NotFound();
            return Ok(chapter);
        }

        // ✅ Tạo chương mới
        [HttpPost]
        public async Task<IActionResult> CreateChapter([FromBody] CreateChapterDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdChapter = await _chapterService.CreateChapterAsync(request);
            if (createdChapter == null) return BadRequest("Không thể tạo chương.");

            return CreatedAtAction(nameof(GetChapterById), new { chapterId = createdChapter.ChapterId }, createdChapter);
        }

        // ✅ Cập nhật chương
        [HttpPut("{chapterId}")]
        public async Task<IActionResult> UpdateChapter(Guid chapterId, [FromBody] UpdateChapterDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _chapterService.UpdateChapterAsync(chapterId, request);
            if (!result) return NotFound("Chương không tồn tại hoặc không thể cập nhật.");

            return NoContent();
        }

        // ✅ Xóa chương
        [HttpDelete("{chapterId}")]
        public async Task<IActionResult> DeleteChapter(Guid chapterId)
        {
            var result = await _chapterService.DeleteChapterAsync(chapterId);
            if (!result) return NotFound("Chương không tồn tại hoặc không thể xóa.");

            return NoContent();
        }
    }
}
