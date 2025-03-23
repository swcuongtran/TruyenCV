using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TruyenCV.Domain.Entities;
using TruyenCV.Domain.Repositories;
using TruyenCV.Infrastructure.Identity;

namespace TruyenCV.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<IdentityApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var mappedUsers = _mapper.Map<IEnumerable<ApplicationUser>>(users);

            foreach (var user in mappedUsers)
            {
                user.UserId = Guid.Parse(users.First(u => u.Id == user.UserId.ToString()).Id); // ✅ Fix ID Mapping
            }

            return mappedUsers;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return null;

            var mappedUser = _mapper.Map<ApplicationUser>(user);
            mappedUser.UserId = Guid.Parse(user.Id); // ✅ Fix ID Mapping
            return mappedUser;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return null;

            var mappedUser = _mapper.Map<ApplicationUser>(user);
            mappedUser.UserId = Guid.Parse(user.Id); // ✅ Fix ID Mapping
            return mappedUser;
        }

        public async Task<ApplicationUser> GetUserByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return null;

            var mappedUser = _mapper.Map<ApplicationUser>(user);
            mappedUser.UserId = Guid.Parse(user.Id); // ✅ Fix ID Mapping
            return mappedUser;
        }

        public async Task<bool> CreateUserAsync(ApplicationUser user, string password)
        {
            var identityUser = _mapper.Map<IdentityApplicationUser>(user);
            identityUser.Id = Guid.NewGuid().ToString(); // ✅ Tạo GUID cho ID
            var result = await _userManager.CreateAsync(identityUser, password);
            return result.Succeeded;
        }

        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            var identityUser = await _userManager.FindByIdAsync(user.UserId.ToString());
            if (identityUser == null) return false;

            _mapper.Map(user, identityUser);
            var result = await _userManager.UpdateAsync(identityUser);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
