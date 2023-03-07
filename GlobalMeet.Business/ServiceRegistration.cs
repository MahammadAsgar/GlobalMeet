using GlobalMeet.Business.Mappings;
using GlobalMeet.Business.Services.Abstractions.Mail;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.Business.Services.Abstractions.User;
using GlobalMeet.Business.Services.Implementations.Mail;
using GlobalMeet.Business.Services.Implementations.Main;
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
            services.AddScoped<IProfessionService, ProfessionService>();
            services.AddScoped<IAboutService, AboutService>();  
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IMeetService, MeetService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IArchivedMeetService, ArchivedMeetService>();
            services.AddAutoMapper(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MapProfile>();
            });
        }
    }
}
