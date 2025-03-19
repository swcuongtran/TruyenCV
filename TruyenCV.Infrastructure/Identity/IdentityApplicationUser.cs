using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Domain.Entities;

namespace TruyenCV.Infrastructure.Identity
{
    public class IdentityApplicationUser:IdentityUser
    {
            public string FullName { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    }
}