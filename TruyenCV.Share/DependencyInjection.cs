using Microsoft.Extensions.DependencyInjection;

namespace TruyenCV.Share
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddShareServices(this IServiceCollection services)
        {
            // Register shared services
            // Example: services.AddTransient<ISharedService, SharedService>();

            return services;
        }
    }
}
