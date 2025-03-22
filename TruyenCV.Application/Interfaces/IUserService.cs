using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruyenCV.Application.DTOs;

namespace TruyenCV.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid userId);
        Task<bool> CreateUserAsync(RegisterRequestDto request);
        Task<bool> UpdateUserAsync(Guid Id,UpdateUserDto userDto);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}