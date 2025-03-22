using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyenCV.Application.DTOs
{
    public class ChapterDto
    {
        public Guid ChapterId { get; set; }
        public Guid StoryId { get; set; }
        public int ChapterNumber { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
