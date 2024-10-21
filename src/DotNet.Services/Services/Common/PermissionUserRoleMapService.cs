using DotNet.ApplicationCore.DTOs;
using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;
using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.Services.Services.Interfaces.Common;
using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Services.Common
{
    //GenericRepository<Users>,
    public class PermissionUserRoleMapService(
        IPermissionUserRoleMapRepository permissionUserRoleMapRepository,
        IPermissionRepository permissionRepository,
        IUserRoleRepository userRoleRepository
            ) : IPermissionUserRoleMapService
    {
        private readonly IPermissionUserRoleMapRepository _permissionUserRoleMapRepository = permissionUserRoleMapRepository;
        private readonly IPermissionRepository _permissionRepository = permissionRepository;
        private readonly IUserRoleRepository _userRoleRepository = userRoleRepository;
        readonly ResponseMessage rm = new();

        public async Task<IEnumerable<PermissionUserRoleMap>> GetAll()
        {
            return await _permissionUserRoleMapRepository.GetAll();
        }
        public async Task<PermissionUserRoleMap?> GetByID(int id)
        {
            var response = await _permissionUserRoleMapRepository.GetByID(id);
            return response;
        }
        public async Task<PermissionUserRoleMap?> Add(PermissionUserRoleMap permissionUserRoleMap)
        {
            var data = await _permissionUserRoleMapRepository.Add(permissionUserRoleMap);
            return data;
        }
        public async Task<IEnumerable<VMPermissionUserRoleMap>> GetListByUserRoleID(int userRoleID)
        {
            var response = await _permissionUserRoleMapRepository.GetListByUserRoleID(userRoleID);
            return response;
        }
        public async Task<bool> UpdatePermissionList(List<VMPermissionUserRoleMap> oList)
        {
            return await _permissionUserRoleMapRepository.UpdatePermissionList(oList);
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _permissionUserRoleMapRepository.Delete(id);
            return response;
        }
        public async Task<ResponseMessage> GetInitialData()
        {
            try
            {
                var lstUserRole = await _userRoleRepository.GetAll();
                var lstPermission = await _permissionRepository.GetAll();
                //var lstPermissionUserRoleMap = await _permissionUserRoleMapRepository.GetAll();


                rm.StatusCode = ReturnStatus.Success;
                rm.ResponseObj = new
                {
                    lstUserRole,
                    lstPermission,
                    //lstPermissionUserRole = lstPermissionUserRoleMap
                };
            }
            catch (Exception ex)
            {
                rm.Message = ex.Message;
                rm.StatusCode = ReturnStatus.Failed;
            }
            return rm;
        }


    }
}
