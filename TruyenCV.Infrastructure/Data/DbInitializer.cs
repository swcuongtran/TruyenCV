using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using TruyenCV.Infrastructure.Identity;

namespace TruyenCV.Infrastructure.Data
{
    public static class DbInitializer
    {
        // ✅ Tạo các Role mặc định
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "User", "Moderator", "Translator" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        // ✅ Tạo tài khoản Admin nếu chưa có
        public static async Task SeedAdminUser(UserManager<IdentityApplicationUser> userManager)
        {
            var adminEmail = "admin@example.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var newAdmin = new IdentityApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FullName = "Administrator",
                    CreatedAt = DateTime.UtcNow
                };

                var result = await userManager.CreateAsync(newAdmin, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }
    }
}
