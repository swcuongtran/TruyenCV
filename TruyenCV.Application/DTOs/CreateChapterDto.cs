using System;

namespace TruyenCV.Application.DTOs
{
    public class CreateChapterDto
    {
        public Guid StoryId { get; set; } 
        public int ChapterNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
