﻿using GlobalMeet.Business.Mappings;
using GlobalMeet.Business.Services.Abstractions.Mail;
using GlobalMeet.Business.Services.Abstractions.Main;
using GlobalMeet.Business.Services.Abstractions.Storage.Local;
using GlobalMeet.Business.Services.Abstractions.User;
using GlobalMeet.Business.Services.Implementations.Mail;
using GlobalMeet.Business.Services.Implementations.Main;
using GlobalMeet.Business.Services.Implementations.Storage.Local;
using GlobalMeet.Business.Services.Implementations.User;
using Microsoft.Extensions.DependencyInjection;


namespace GlobalMeet.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IFileStorage, FileStorage>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyFileService, CompanyFileService>();
            services.AddScoped<ICompanyCategoryService, CompanyCategoryService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAboutFileService, AboutFileService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IBlogFileService, BlogFileService>();
            services.AddScoped<IMeetService, MeetService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPolicyTypeService, PolicyTypeService>();
            services.AddScoped<IPrivacyPolicyService, PrivacyPolicyService>();
            services.AddScoped<IMeetTypeService, MeetTypeService>();
            services.AddAutoMapper(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MapProfile>();
            });
        }
    }
}