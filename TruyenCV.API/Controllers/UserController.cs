using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruyenCV.Application.DTOs;
using TruyenCV.Application.Interfaces;

namespace TruyenCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // ✅ Lấy danh sách người dùng
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        // ✅ Lấy thông tin một người dùng theo ID
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null) return NotFound("Người dùng không tồn tại.");
            return Ok(user);
        }

        // ✅ Tạo người dùng mới
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userService.CreateUserAsync(request);
            if (!result) return BadRequest("Không thể tạo tài khoản.");

            return Ok("Tạo tài khoản thành công.");
        }

        // ✅ Cập nhật thông tin người dùng
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userService.UpdateUserAsync(userId, request);
            if (!result) return NotFound("Người dùng không tồn tại hoặc không thể cập nhật.");

            return NoContent();
        }

        // ✅ Xóa người dùng
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var result = await _userService.DeleteUserAsync(userId);
            if (!result) return NotFound("Người dùng không tồn tại hoặc không thể xóa.");

            return NoContent();
        }
    }
}
