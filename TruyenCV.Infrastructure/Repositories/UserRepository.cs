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
            return _mapper.Map<IEnumerable<ApplicationUser>>(users);
        }

        public async Task<ApplicationUser> GetUserByIdAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user != null ? _mapper.Map<ApplicationUser>(user) : null;
        }

        public async Task<bool> CreateUserAsync(ApplicationUser user, string password)
        {
            var identityUser = _mapper.Map<IdentityApplicationUser>(user);
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
