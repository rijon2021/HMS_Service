using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.DTOs.VM;


namespace DotNet.Services.Repositories.Interfaces.Common
{
    public interface IUserRepository
    {
        AuthUser UserAuthentication(AuthUser userResponse);
        Task<IEnumerable<Users>> GetAll();
        Task<Users?> GetByID(int id);
        Task<Users?> GetByUserID(string userID);
        Task<Users?> Add(Users entity);
        Task<Users> Update(Users entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<VMUsers>> GetAllByOrganizationID();
        Task<IEnumerable<VMUsers>> GetAllByDepartmentID(int id);
        Task<IEnumerable<VMUsers>> GetAllByLoginUserDepartmentID();
        Task<IEnumerable<VMUsers>> GetAllByDepartmentApplicationMap();
        Task<ResponseMessage> ChangePassword(VMUsers user);
    }
}
