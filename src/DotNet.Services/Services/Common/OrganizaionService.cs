using DotNet.ApplicationCore.DTOs;
using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;
using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.Services.Services.Interfaces.Common;
using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Services.Common
{
    //GenericRepository<Users>,
    public class OrganizaionService(
        IOrganizationRepository organizationRepository,
        IUserRepository userRepository
            ) : IOrganizaionService
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;
        private readonly IUserRepository _userRepository = userRepository;
        readonly ResponseMessage rm = new();

        public async Task<IEnumerable<Organization>> GetAll()
        {
            //throw new Exception(string.Format("{0} - {1}", "dont worry with error", StatusCodes.Status402PaymentRequired));
            return await _organizationRepository.GetAll();
        }
        public async Task<Organization?> GetByID(int id)
        {
            var response = await _organizationRepository.GetByID(id);
            //throw new Exception(string.Format("{0} - {1}", "dont worry with error", StatusCodes.Status402PaymentRequired));
            return response;
        }
        public async Task<Organization?> Add(Organization organization)
        {
            var data = await _organizationRepository.Add(organization);
            return data;
        }
        public async Task<Organization?> Update(Organization organization)
        {
            return await _organizationRepository.Update(organization);
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _organizationRepository.Delete(id);
            return response;
        }
        public async Task<ResponseMessage> GetInitialData()
        {
            try
            {
                var lstUsers = await _userRepository.GetAll();

                rm.StatusCode = ReturnStatus.Success;
                rm.ResponseObj = new
                {
                    lstUsers,
                };
            }
            catch (Exception ex)
            {
                rm.Message = ex.Message;
                rm.StatusCode = ReturnStatus.Failed;
            }
            return rm;
        }

    }
}
