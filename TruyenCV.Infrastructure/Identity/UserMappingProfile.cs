using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Domain.Entities;

namespace TruyenCV.Infrastructure.Identity
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<ApplicationUser, IdentityApplicationUser>().ReverseMap();
        }
    }
}
