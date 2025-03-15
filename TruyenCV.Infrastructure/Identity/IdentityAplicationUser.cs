using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Domain.Entities;

namespace TruyenCV.Infrastructure.Identity
{
    public class IdentityAplicationUser:IdentityUser
    {
            public string FullName { get; set; }
            public DateTime CreatedAt { get; set; }
            public ICollection<Role> Roles { get; set; }   
    }
}
