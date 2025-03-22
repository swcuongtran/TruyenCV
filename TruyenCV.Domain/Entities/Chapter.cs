using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyenCV.Domain.Entities
{
    public class Chapter
    {
        public Guid ChapterId { get; set; }
        public Guid StoryId { get; set; }
        public int ChapterNumber { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Quan hệ với Story
        public Story Story { get; set; }
    }
}
