using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TruyenCV.Application.DTOs;
using TruyenCV.Application.Interfaces;
using TruyenCV.Domain.Repositories;

namespace TruyenCV.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        // ✅ Lấy danh sách tất cả các roles
        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return roles.Select(role => new RoleDto { RoleName = role }).ToList();
        }

        // ✅ Tạo role mới
        public async Task<bool> CreateRoleAsync(string roleName)
        {
            return await _roleRepository.CreateRoleAsync(roleName);
        }

        // ✅ Xóa role
        public async Task<bool> DeleteRoleAsync(string roleName)
        {
            return await _roleRepository.DeleteRoleAsync(roleName);
        }

        // ✅ Gán role cho user
        public async Task<bool> AssignRoleToUserAsync(Guid userId, string roleName)
        {
            return await _roleRepository.AssignRoleToUserAsync(userId, roleName);
        }

        // ✅ Xóa role khỏi user
        public async Task<bool> RemoveRoleFromUserAsync(Guid userId, string roleName)
        {
            return await _roleRepository.RemoveRoleFromUserAsync(userId, roleName);
        }

        // ✅ Lấy danh sách roles của user
        public async Task<IEnumerable<string>> GetUserRolesAsync(Guid userId)
        {
            return await _roleRepository.GetUserRolesAsync(userId);
        }
    }
}
