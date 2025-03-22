using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TruyenCV.Domain.Entities
{
    public class Story
    {
        public Guid StoryId { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public int ViewCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Quan hệ với Chapter
        public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();

        // Quan hệ với Comment
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
