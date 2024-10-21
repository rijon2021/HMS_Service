using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Repositories.Interfaces.Common
{

    public interface IPermissionUserRoleMapRepository //: ICommonRepository<PermissionUserRoleMap>
    {
        Task<IEnumerable<PermissionUserRoleMap>> GetAll();
        Task<PermissionUserRoleMap?> GetByID(int id);
        Task<PermissionUserRoleMap?> Add(PermissionUserRoleMap entity);
        Task<IEnumerable<VMPermissionUserRoleMap>> GetListByUserRoleID(int userRoleID);
        Task<bool> UpdatePermissionList(List<VMPermissionUserRoleMap> oList);
        Task<bool> Delete(int id);

    }
}
