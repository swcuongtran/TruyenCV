using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruyenCV.Application.Interfaces;
using TruyenCV.Application.DTOs;

namespace TruyenCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // ✅ Lấy danh sách vai trò
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        // ✅ Tạo vai trò mới
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleDto request)
        {
            if (string.IsNullOrWhiteSpace(request.RoleName))
                return BadRequest("Tên vai trò không hợp lệ.");

            var result = await _roleService.CreateRoleAsync(request.RoleName);
            if (!result) return BadRequest($"Không thể tạo vai trò '{request.RoleName}'.");

            return Ok($"Vai trò '{request.RoleName}' đã được tạo.");
        }

        // ✅ Xóa vai trò
        [HttpDelete("{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var result = await _roleService.DeleteRoleAsync(roleName);
            if (!result) return NotFound($"Vai trò '{roleName}' không tồn tại hoặc không thể xóa.");

            return NoContent();
        }

        // ✅ Gán vai trò cho người dùng
        [HttpPost("assign")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleDto request)
        {
            if (request.UserId == Guid.Empty || string.IsNullOrWhiteSpace(request.RoleName))
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _roleService.AssignRoleToUserAsync(request.UserId, request.RoleName);
            if (!result) return BadRequest($"Không thể gán vai trò '{request.RoleName}'.");

            return Ok($"Đã gán vai trò '{request.RoleName}' cho người dùng.");
        }

        // ✅ Xóa vai trò khỏi người dùng
        [HttpPost("remove")]
        public async Task<IActionResult> RemoveRoleFromUser([FromBody] AssignRoleDto request)
        {
            if (request.UserId == Guid.Empty || string.IsNullOrWhiteSpace(request.RoleName))
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _roleService.RemoveRoleFromUserAsync(request.UserId, request.RoleName);
            if (!result) return BadRequest($"Không thể xóa vai trò '{request.RoleName}'.");

            return Ok($"Đã xóa vai trò '{request.RoleName}' khỏi người dùng.");
        }

        // ✅ Lấy danh sách vai trò của một người dùng
        [HttpGet("{userId}/roles")]
        public async Task<IActionResult> GetUserRoles(Guid userId)
        {
            if (userId == Guid.Empty) return BadRequest("ID người dùng không hợp lệ.");

            var roles = await _roleService.GetUserRolesAsync(userId);
            return Ok(roles);
        }
    }
}
