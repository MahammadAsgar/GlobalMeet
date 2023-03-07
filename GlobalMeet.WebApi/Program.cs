using GlobalMeet.Business;
using GlobalMeet.Business.Mappings;
using GlobalMeet.DataAccess;
using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.User;
using GlobalMeet.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<GlobalMeetDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MeetString")));

// Add services to the container.



#region Identity

builder.Services.AddIdentity<AppUser, AppRole>(config =>
{
    config.Stores.MaxLengthForKeys = 128;
    config.Password.RequireDigit = false;
    config.Password.RequireLowercase = false;
    config.Password.RequiredLength = 4;
    config.Password.RequiredUniqueChars = 0;
    config.Password.RequireLowercase = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase = false;

})
     .AddEntityFrameworkStores<GlobalMeetDbContext>()
.AddDefaultTokenProviders();
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
    cfg.AddProfile<MapProfile>();
});
#endregion
#region Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(conf =>
{
    conf.IdleTimeout = TimeSpan.FromHours(1);
    conf.Cookie.HttpOnly = false;
    conf.Cookie.IsEssential = true;
    conf.Cookie.SameSite = SameSiteMode.None;
    conf.Cookie.SecurePolicy = CookieSecurePolicy.Always;

});
#endregion
builder.Services.AddHttpContextAccessor();
builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices();
builder.Services.AddInfrastructureServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Swagger Implementation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GlobalMeet.WebApi", Version = "v1" });

    //include description from method xml comments
    var path = Path.Combine(AppContext.BaseDirectory, "GlobalMeet.WebApi.xml");
    //c.IncludeXmlComments(path);

    //add jwt security bearer
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "please insert token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                   {
                       {
                           new OpenApiSecurityScheme
                           {
                               Reference= new OpenApiReference
                               {
                                   Type=ReferenceType.SecurityScheme,
                                   Id="Bearer"
                               }
                           },
                           new string[] { }
                       }
                   });
});
builder.Services.AddAuthentication();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("superadmin", policy => policy.RequireRole("superadmin", "admin"));
    options.AddPolicy("admin", policy => policy.RequireRole("admin"));
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GlobalMeet.WebApi v1"));
}

else
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GlobalMeet.WebApi v1"));

}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
