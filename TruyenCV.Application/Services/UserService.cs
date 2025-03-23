using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TruyenCV.Application.DTOs;
using TruyenCV.Application.Interfaces;
using TruyenCV.Domain.Entities;
using TruyenCV.Domain.Repositories;

namespace TruyenCV.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleService _roleService; // ✅ Thêm RoleService
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IRoleService roleService, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleService = roleService; // ✅ Inject RoleService
            _mapper = mapper;
        }

        // ✅ Lấy danh sách user kèm theo role
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            foreach (var userDto in userDtos)
            {
                userDto.Roles = (await _roleService.GetUserRolesAsync(userDto.UserId)).ToList();
            }

            return userDtos;
        }

        // ✅ Lấy thông tin user theo ID kèm theo role
        public async Task<UserDto> GetUserByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return null;

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Roles = (await _roleService.GetUserRolesAsync(userId)).ToList();

            return userDto;
        }

        // ✅ Tạo user mới
        public async Task<bool> CreateUserAsync(RegisterRequestDto request)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            return await _userRepository.CreateUserAsync(user, request.Password);
        }

        // ✅ Cập nhật thông tin user
        public async Task<bool> UpdateUserAsync(Guid userId, UpdateUserDto request)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return false;

            _mapper.Map(request, user);
            return await _userRepository.UpdateUserAsync(user);
        }

        // ✅ Xóa user
        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return await _userRepository.DeleteUserAsync(userId);
        }
    }
}
