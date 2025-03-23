using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TruyenCV.Application.Interfaces;
using TruyenCV.Application.Services;
using TruyenCV.Domain.Entities;
using TruyenCV.Domain.Repositories;
using TruyenCV.Infrastructure.Data;
using TruyenCV.Infrastructure.Identity;
using TruyenCV.Infrastructure.Repositories;

namespace TruyenCV.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Đăng ký DbContext chính cho ứng dụng
            services.AddDbContext<TruyenDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgreConnection")));

            // Đăng ký DbContext cho Identity
            services.AddDbContext<IdentityDatabaseContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<IdentityApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false; // Không bắt buộc có số
                options.Password.RequireLowercase = true; // Phải có chữ thường
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in hoa
                options.Password.RequireNonAlphanumeric = false; // Không bắt buộc ký tự đặc biệt
                options.Password.RequiredLength = 6; // Độ dài tối thiểu
            })
                .AddEntityFrameworkStores<IdentityDatabaseContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<UserManager<IdentityApplicationUser>>();
            services.AddScoped<RoleManager<IdentityRole>>();
            // Đăng ký AutoMapper
            services.AddAutoMapper(typeof(UserMappingProfile));

            //Đang ký các Repository
            services.AddScoped<IChapterRepositoy, ChapterRepository>();
            services.AddScoped<IStoryRepository, StoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            

            //Đăng kí jwt
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();


            return services;
        }
    }
}
