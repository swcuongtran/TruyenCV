using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            services.AddIdentity<IdentityApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDatabaseContext>()
                .AddDefaultTokenProviders();
            // Đăng ký AutoMapper
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);

            //Đang ký các Repository
            services.AddScoped<IChapterRepositoy, ChapterRepository>();
          


            return services;
        }
    }
}
