using DotNet.ApplicationCore.DTOs.VM;
using DotNet.ApplicationCore.DTOs.Common;
using DotNet.Services.Services.Interfaces;
using DotNet.Services.Repositories.Interfaces;


namespace DotNet.Services.Services
{
    public class AdminDashboardService(IAdminDashboardRepository adminDashboardRepo) : IAdminDashboardService
    {
        private readonly IAdminDashboardRepository adminDashboardRepo = adminDashboardRepo;

        //public async Task<VMAdminDashboard> GetAdminDashboard()
        //{
        //    var response = await adminDashboardRepo.GetAdminDashboard();
        //    return response;
        //}

        //public async Task<List<VMAdminDashboardFileUserWise>> GetFileListByFileType(int type)
        //{
        //    var response = await adminDashboardRepo.GetFileListByFileType(type);
        //    return response;
        //}

        //public async Task<List<VMAdminDashboardFileListUserWise>> GetFileListByTypeVisitedUser(QueryObject queryObject)
        //{
        //    var response = await adminDashboardRepo.GetFileListByTypeVisitedUser(queryObject);
        //    return response;
        //}
    }
}
