using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruyenCV.Application.DTOs;
using TruyenCV.Application.Interfaces;

namespace TruyenChu.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // ✅ API Đăng ký tài khoản
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _authService.RegisterAsync(request);
            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        // ✅ API Đăng nhập và lấy Token
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _authService.LoginAsync(request);
            if (!response.IsSuccess)
                return Unauthorized(response);

            return Ok(response);
        }
    }
}
