using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DotNet.ApplicationCore.DTOs.VM;
using DotNet.ApplicationCore.DTOs.Common;
using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.Utils.Helper;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Services.Repositories.Interfaces;
using DotNet.Services.Repositories.Interfaces.Common;

using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;


namespace DotNet.Services.Repositories
{
    public class AdminDashboardRepository(DotNetContext dbContext, IHttpContextAccessor httpContextAccessor, IUserRoleRepository userRoleRepo) : IAdminDashboardRepository
    {
        private readonly DotNetContext dbContext = dbContext;
        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;
        private readonly IUserRoleRepository userRoleRepo = userRoleRepo;


    }
}
