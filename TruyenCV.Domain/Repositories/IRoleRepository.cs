using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TruyenCV.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<string>> GetAllRolesAsync(); // ✅ Lấy danh sách roles
        Task<bool> CreateRoleAsync(string roleName);  // ✅ Tạo role mới
        Task<bool> DeleteRoleAsync(string roleName);  // ✅ Xóa role
        Task<bool> AssignRoleToUserAsync(Guid userId, string roleName);  // ✅ Gán role cho user
        Task<bool> RemoveRoleFromUserAsync(Guid userId, string roleName); // ✅ Xóa role khỏi user
        Task<IEnumerable<string>> GetUserRolesAsync(Guid userId); // ✅ Lấy danh sách roles của user
    }
}
