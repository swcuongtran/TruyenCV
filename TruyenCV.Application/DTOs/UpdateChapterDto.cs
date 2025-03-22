using System;

namespace TruyenCV.Application.DTOs
{
    public class UpdateChapterDto
    {
        public string Title { get; set; } = string.Empty;
        public int ChapterNumber { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
