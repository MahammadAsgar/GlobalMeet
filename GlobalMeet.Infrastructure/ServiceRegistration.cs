using GlobalMeet.Infrastructure.Utilities.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalMeet.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();
        }
    }
}
