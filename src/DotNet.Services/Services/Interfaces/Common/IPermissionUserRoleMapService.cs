using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Services.Interfaces.Common
{
    public interface IPermissionUserRoleMapService //: ICommonInterface<PermissionUserRoleMap>
    {
        Task<IEnumerable<PermissionUserRoleMap>> GetAll();
        Task<PermissionUserRoleMap?> GetByID(int id);
        Task<PermissionUserRoleMap?> Add(PermissionUserRoleMap entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<VMPermissionUserRoleMap>> GetListByUserRoleID(int userRoleID);
        Task<bool> UpdatePermissionList(List<VMPermissionUserRoleMap> oList);
        Task<ResponseMessage> GetInitialData();
    }
}
