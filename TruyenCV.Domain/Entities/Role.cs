﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyenCV.Domain.Entities
{
    public class Role
    {
        public Guid RoleId { get; set; }  
        public string Name { get; set; } = null!;
        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
