using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Application.DTOs;

namespace TruyenCV.Application.Interfaces
{
    public interface IStoryService
    {
        Task<IEnumerable<StoryDto>> GetStoriesAsync(); 
        Task<StoryDto> GetStoryByIdAsync(Guid storyId);
        Task<bool> CreateStoryAsync(StoryDto storyDto);
        Task<bool> UpdateStoryAsync(Guid storyId, StoryDto storyDto); 
        Task<bool> DeleteStoryAsync(Guid storyId); 
        Task IncreaseViewCountAsync(Guid storyId); 
    }
}
