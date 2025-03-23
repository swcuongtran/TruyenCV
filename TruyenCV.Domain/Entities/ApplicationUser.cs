using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TruyenCV.Domain.Entities
{
    public class ApplicationUser
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool EmailConfirmed { get; set; } 
        public string? PhoneNumber { get; set; }
        public string FullName { get; set; } = null!;
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Quan hệ với Role (User có nhiều Role)
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
