using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Repositories.Interfaces.Common
{

    public interface IOrganizationRepository //: ICommonRepository<UserRole>
    {
        Task<IEnumerable<Organization>> GetAll();
        Task<Organization?> GetByID(int id);
        Task<Organization?> Add(Organization entity);
        Task<Organization?> Update(Organization entity);
        Task<bool> Delete(int id);
    }
}
