using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyenCV.Domain.Entities
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public Guid StoryId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Quan hệ với Story
        public Story Story { get; set; }

        // Quan hệ với ApplicationUser
        public ApplicationUser User { get; set; }
    }
}
