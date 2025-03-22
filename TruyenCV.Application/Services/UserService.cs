using System;
using System.Collections.Generic;
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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // ✅ Lấy danh sách user
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        // ✅ Lấy thông tin user theo ID
        public async Task<UserDto> GetUserByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user != null ? _mapper.Map<UserDto>(user) : null;
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
