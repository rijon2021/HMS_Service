using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Services.Interfaces.Common
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRole>> GetAll();
        Task<UserRole?> GetByID(int id);
        Task<UserRole?> Add(UserRole entity);
        Task<UserRole> Update(UserRole entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<UserRole>> UpdateOrder(List<UserRole> oList);
    }
}
