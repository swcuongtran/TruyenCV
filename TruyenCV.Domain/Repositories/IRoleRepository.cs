using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Domain.Entities;

namespace TruyenCV.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role> GetRoleByIdAsync(Guid roleId);
        Task<Role> CreateRoleAsync(Role role);
        Task UpdateRoleAsync(Guid roleId, Role role);
        Task DeleteRoleAsync(Guid roleId);
    }
}
