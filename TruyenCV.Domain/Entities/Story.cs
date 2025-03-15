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
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Quan hệ với Chapter
        public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();

        // Quan hệ với Comment
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
