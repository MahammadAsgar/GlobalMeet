using GlobalMeet.Business.Mappings;
using GlobalMeet.Business.Services.Abstractions.Mail;
using GlobalMeet.Business.Services.Abstractions.User;
using GlobalMeet.Business.Services.Implementations.Mail;
using GlobalMeet.Business.Services.Implementations.User;
using Microsoft.Extensions.DependencyInjection;


namespace GlobalMeet.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMailService, MailService>();

            services.AddAutoMapper(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MapProfile>();
            });
        }
    }
}
