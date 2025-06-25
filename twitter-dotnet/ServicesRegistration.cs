

using DotnetAPI.Repository;
using DotnetAPI.Repository.Interfaces;

namespace DotnetAPI
{
    public static class ServicesRegistration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPostRepo, PostRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IAuthRepo, AuthRepo>();
            services.AddScoped<IFollowRepo, FollowRepo>();
        }
    }
}