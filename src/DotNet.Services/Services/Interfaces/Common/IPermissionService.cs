using DotNet.ApplicationCore.DTOs.Common;
using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Services.Interfaces.Common
{
    public interface IPermissionService //: ICommonInterface<Permission>
    {
        Task<IEnumerable<Permission>> GetAll();
        Task<Permission?> GetByID(int id);
        Task<Permission?> Add(Permission entity);
        Task<Permission> Update(Permission entity);
        Task<bool> Delete(int id);
        List<PermissionDTO> MakeListWithChild(List<Permission> oList);
        Task<IEnumerable<Permission>> UpdateOrder(List<Permission> oList);
        Task<IEnumerable<Permission>> GetListByUserRoleID(int id);
    }
}
