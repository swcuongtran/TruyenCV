using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Application.DTOs;
using TruyenCV.Domain.Entities;


namespace TruyenCV.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<Chapter, ChapterDto>().ReverseMap();
            CreateMap<CreateChapterDto, Chapter>()
                .ForMember(dest => dest.ChapterId, opt => opt.Ignore()); // ✅ ID sẽ được DB tự sinh
            CreateMap<UpdateChapterDto, Chapter>()
                .ForMember(dest => dest.ChapterId, opt => opt.Ignore()) // Không được thay đổi ID
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()); // Không được sửa CreatedAt
            CreateMap<Story, StoryDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RegisterRequestDto, ApplicationUser>().ReverseMap();
        }
    }
}
