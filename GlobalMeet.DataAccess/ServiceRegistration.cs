using GlobalMeet.DataAccess.Repositories;
using GlobalMeet.DataAccess.Repositories.Abstractions.Main;
using GlobalMeet.DataAccess.Repositories.Implementations.Main;
using GlobalMeet.DataAccess.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;


namespace GlobalMeet.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IAboutFileRepository, AboutFileRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogFileRepsitory, BlogFileRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IMeetDateRepository, MeetDateRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICompanyCategoryRepository, CompanyCategoryRepository>();
        }
    }
}
