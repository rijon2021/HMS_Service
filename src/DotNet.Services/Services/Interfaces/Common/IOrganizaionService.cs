using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Services.Interfaces.Common
{
    public interface IOrganizaionService //: ICommonInterface<UserRole>
    {
        Task<IEnumerable<Organization>> GetAll();
        Task<Organization?> GetByID(int id);
        Task<Organization?> Add(Organization entity);
        Task<Organization?> Update(Organization entity);
        Task<bool> Delete(int id);
        Task<ResponseMessage> GetInitialData();
    }
}
