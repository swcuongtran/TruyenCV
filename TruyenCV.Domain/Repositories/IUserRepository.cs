using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyenCV.Domain.Entities;

namespace TruyenCV.Domain.Repositories
{
    interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(Guid userId);
        Task<ApplicationUser> CreateUserAsync(ApplicationUser user);
        Task UpdateUserAsync(Guid userId, ApplicationUser user);
        Task DeleteUserAsync(Guid userId);
    }
}
