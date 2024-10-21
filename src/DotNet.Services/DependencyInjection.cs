using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotNet.Infrastructure.Persistence.Contexts;
using System.Diagnostics.CodeAnalysis;
using DotNet.Services.Repositories.Common;
using DotNet.Services.Repositories.Infrastructure;
using DotNet.Services.Services.Infrastructure;
using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.Services.Services.Interfaces.Common;
using DotNet.Services.Services.Common;
using DotNet.Services.Repositories.Interfaces;
using DotNet.Services.Repositories;
using DotNet.Services.Services.Interfaces;
using DotNet.Services.Services;


namespace DotNet.Services
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DotNetContext>(options => options.UseSqlServer(defaultConnectionString));
            services.AddScoped<DbContext, DotNetContext>();

            AddRepositories(services);
            AddServices(services);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var serviceProvider = services.BuildServiceProvider();
            try
            {
                var dbContext = serviceProvider.GetRequiredService<DotNetContext>();
                dbContext.Database.Migrate();
            }
            catch
            {
            }

            return services;
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IGlobalSettingRepository, GlobalSettingRepository>();
            services.AddScoped<INotificationAreaRepository, NotificationAreaRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IPermissionUserRoleMapRepository, PermissionUserRoleMapRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IAttachmentsRepository, AttachmentsRepository>();
            services.AddScoped<IAdminDashboardRepository, AdminDashboardRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IGlobalSettingService, GlobalSettingService>();
            services.AddScoped<INotificationAreaService, NotificationAreaService>();
            services.AddScoped<IOrganizaionService, OrganizaionService>();
            services.AddScoped<IPermissionUserRoleMapService, PermissionUserRoleMapService>();
            services.AddScoped<IDesignationService, DesignationService>();

            services.AddScoped<IAttachmentsService, AttachmentsService>();
            services.AddScoped<IAdminDashboardService, AdminDashboardService>();


        }
    }
}
