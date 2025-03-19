using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TruyenCV.Application.DTOs;
using TruyenCV.Application.Interfaces;
using TruyenCV.Domain.Entities;

namespace TruyenCV.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        // ✅ Lấy danh sách User (Trả về DTO)
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = _userManager.Users;
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        // ✅ Lấy thông tin User theo ID (Trả về DTO)
        public async Task<UserDto> GetUserByIdAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user != null ? _mapper.Map<UserDto>(user) : null;
        }

        // ✅ Tạo User mới (Không phụ thuộc vào Infrastructure)
        public async Task<bool> CreateUserAsync(RegisterRequestDto request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = request.FullName
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            return result.Succeeded;
        }

        // ✅ Cập nhật User
        public async Task<bool> UpdateUserAsync(UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.UserId.ToString());
            if (user == null) return false;

            user.FullName = userDto.FullName;
            user.Email = userDto.Email;
            user.UserName = userDto.Email;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        // ✅ Xóa User
        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
