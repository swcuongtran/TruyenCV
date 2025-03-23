using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyenCV.Application.DTOs
{
    public class AuthResponseDto
    {
        public bool IsSuccess { get; set; } = false;
        public string Token { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();
        public List<string> Roles { get; set; } = new();
    }
}
