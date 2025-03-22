using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruyenCV.Application.DTOs;
using TruyenCV.Application.Interfaces;

[Route("api/stories")]
[ApiController]
public class StoryController : ControllerBase
{
    private readonly IStoryService _storyService;

    public StoryController(IStoryService storyService)
    {
        _storyService = storyService;
    }

    // ✅ Lấy danh sách truyện
    [HttpGet]
    public async Task<IActionResult> GetStories()
    {
        var stories = await _storyService.GetStoriesAsync();
        return Ok(stories);
    }

    // ✅ Lấy truyện theo ID (Tự động tăng ViewCount khi xem)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStoryById(Guid id)
    {
        var story = await _storyService.GetStoryByIdAsync(id);
        return story != null ? Ok(story) : NotFound();
    }

    // ✅ Tạo truyện mới
    [HttpPost]
    public async Task<IActionResult> CreateStory([FromBody] StoryDto storyDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _storyService.CreateStoryAsync(storyDto);
        return result ? Ok("Story created successfully") : BadRequest("Story creation failed");
    }

    // ✅ Cập nhật truyện
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStory(Guid id, [FromBody] StoryDto storyDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _storyService.UpdateStoryAsync(id, storyDto);
        return result ? NoContent() : BadRequest("Update failed");
    }

    // ✅ Xóa truyện
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStory(Guid id)
    {
        var result = await _storyService.DeleteStoryAsync(id);
        return result ? NoContent() : BadRequest("Delete failed");
    }

    // ✅ Tăng lượt xem (Dùng khi cần tăng ViewCount mà không cần gọi `GetStoryById`)
    [HttpPost("{id}/increase-view")]
    public async Task<IActionResult> IncreaseViewCount(Guid id)
    {
        await _storyService.IncreaseViewCountAsync(id);
        return Ok("View count increased");
    }
}
