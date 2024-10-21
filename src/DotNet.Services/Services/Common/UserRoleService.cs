using DotNet.ApplicationCore.Entities;

using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.Services.Services.Interfaces.Common;


namespace DotNet.Services.Services.Common
{
    public class UserRoleService(IUserRoleRepository userRoleRepo) : IUserRoleService
    {
        private readonly IUserRoleRepository userRoleRepo = userRoleRepo;


        public async Task<IEnumerable<UserRole>> GetAll()
        {
            return await userRoleRepo.GetAll();
        }

        public async Task<UserRole?> GetByID(int id)
        {
            var response = await userRoleRepo.GetByID(id);
            return response;
        }

        public async Task<UserRole?> Add(UserRole userLevel)
        {
            var data = await userRoleRepo.Add(userLevel);
            return data;
        }

        public async Task<UserRole> Update(UserRole userLevel)
        {
            return await userRoleRepo.Update(userLevel);
        }

        public async Task<bool> Delete(int id)
        {
            var response = await userRoleRepo.Delete(id);
            return response;
        }

        public async Task<IEnumerable<UserRole>> UpdateOrder(List<UserRole> oList)
        {
            return await userRoleRepo.UpdateOrder(oList);
        }
    }
}
