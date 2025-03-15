using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Domain.Entities;

namespace TruyenCV.Domain.Repositories
{
    public interface IStoryRepository
    {
        Task<IEnumerable<Story>> GetStoriesAsync();
        Task<Story> GetStoryByIdAsync(Guid storyId);
        Task<Story> CreateStoryAsync(Story story);
        Task UpdateStoryAsync(Guid storyId, Story story);
        Task DeleteStoryAsync(Guid storyId);
    }
}
