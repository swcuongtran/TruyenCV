using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TruyenCV.Domain.Entities;
using TruyenCV.Infrastructure.Data;

namespace TruyenCV.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Đăng ký DbContext chính cho ứng dụng
            services.AddDbContext<TruyenDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("NZWalksConnectionString")));

            // Đăng ký DbContext cho Identity
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("NZWalksAuthConnectionString")));

            // Đăng ký AutoMapper
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
