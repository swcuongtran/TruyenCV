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
            CreateMap<IdentityApplicationUser, ApplicationUser>()
    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => Guid.Parse(src.Id))) // ✅ Chuyển đổi ID đúng
    .ReverseMap()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId.ToString())); // ✅ Đổi lại khi map ngược

        }
    }
}
