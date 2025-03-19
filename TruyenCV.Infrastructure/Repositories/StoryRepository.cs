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
    public class StoryRepository : IStoryRepository
    {
        private readonly TruyenDbContext _context;

        public StoryRepository(TruyenDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Story>> GetStoriesAsync()
        {
            return await _context.Stories.ToListAsync();
        }

        public async Task<Story> GetStoryByIdAsync(Guid storyId)
        {
            return await _context.Stories.FindAsync(storyId);
        }

        public async Task<Story> CreateStoryAsync(Story story)
        {
            _context.Stories.Add(story);
            await _context.SaveChangesAsync();
            return story;
        }

        public async Task UpdateStoryAsync(Guid storyId, Story story)
        {
            var existingStory = await _context.Stories.FindAsync(storyId);
            if (existingStory != null)
            {
                existingStory.Title = story.Title;
                existingStory.Description = story.Description;
                existingStory.CoverImageUrl = story.CoverImageUrl;

                _context.Stories.Update(existingStory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteStoryAsync(Guid storyId)
        {
            var story = await _context.Stories.FindAsync(storyId);
            if (story != null)
            {
                _context.Stories.Remove(story);
                await _context.SaveChangesAsync();
            }
        }

        public async Task IncrementViewCountAsync(Guid storyId)
        {
            var story = await _context.Stories.FindAsync(storyId);
            if (story != null)
            {
                story.ViewCount += 1;
                await _context.SaveChangesAsync();
            }
        }
    }
}
