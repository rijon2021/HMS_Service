using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Repositories.Interfaces.Common
{

    public interface IPermissionRepository //: ICommonRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetAll();
        Task<Permission?> GetByID(int id);
        Task<Permission?> Add(Permission entity);
        Task<Permission> Update(Permission entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<Permission>> UpdateOrder(List<Permission> oList);
        Task<IEnumerable<Permission>> GetListByUserRoleID(int id);

    }
}
