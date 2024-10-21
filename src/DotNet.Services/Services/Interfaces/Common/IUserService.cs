using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.DTOs.VM;
using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Services.Interfaces.Common
{
    public interface IUserService //: ICommonInterface<Users>
    {
        ResponseMessage UserAuthentication(AuthUser userResponse);
        Task<IEnumerable<Users>> GetAll();
        Task<Users?> GetByID(int id);
        Task<Users?> Add(Users entity);
        Task<Users> Update(Users entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<VMUsers>> GetAllByOrganizationID();
        Task<IEnumerable<VMUsers>> GetAllByDepartmentID(int id);
        Task<ResponseMessage> GetInitialData();
        Task<ResponseMessage> ChangePassword(VMUsers user);
    }
}
