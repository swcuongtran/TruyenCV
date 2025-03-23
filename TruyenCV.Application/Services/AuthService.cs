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
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public AuthService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper, IRoleService roleService)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
            _roleService = roleService;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            var existingUserByEmail = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUserByEmail != null)
            {
                return new AuthResponseDto { IsSuccess = false, Errors = new List<string> { "Email đã tồn tại!" } };
            }

            var existingUserByUserName = await _userRepository.GetUserByUserNameAsync(request.UserName);
            if (existingUserByUserName != null)
            {
                return new AuthResponseDto { IsSuccess = false, Errors = new List<string> { "UserName đã tồn tại!" } };
            }

            var user = _mapper.Map<ApplicationUser>(request);
            user.CreatedAt = DateTime.UtcNow;

            var result = await _userRepository.CreateUserAsync(user, request.Password);
            if (!result)
            {
                return new AuthResponseDto { IsSuccess = false, Errors = new List<string> { "Không thể tạo tài khoản." } };
            }

            // ✅ Gán Role mặc định là "User" thông qua RoleService
            await _roleService.AssignRoleToUserAsync(user.UserId, "User");

            var token = _jwtTokenGenerator.GenerateToken(user.UserId.ToString(), user.Email, user.FullName, new List<string> { "User" });

            return new AuthResponseDto { IsSuccess = true, Token = token, Roles = new List<string> { "User" } };
        }


        // ✅ Đăng nhập người dùng
        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                return new AuthResponseDto { IsSuccess = false, Errors = new List<string> { "Email hoặc mật khẩu không chính xác." } };
            }

            // ✅ Tạo token
            var token = _jwtTokenGenerator.GenerateToken(user.UserId.ToString(), user.Email, user.FullName, new List<string> { "User" });

            return new AuthResponseDto { IsSuccess = true, Token = token };
        }
    }
}
