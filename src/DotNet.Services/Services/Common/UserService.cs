using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.DTOs.VM;
using DotNet.Services.Services.Interfaces.Common;
using DotNet.Services.Repositories.Infrastructure;
using DotNet.Services.Repositories.Interfaces.Common;

using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;


namespace DotNet.Services.Services.Common
{
    public class UserService(
        IUserRepository userRepo,
        ICommonRepository commonRepo,
        INotificationAreaRepository notificationAreaRepo,
        IOrganizationRepository organizationRepo,
        IUserRoleRepository userRoleRepo,
        IDesignationRepository designationRepo
     
            ) : IUserService
    {
        private readonly IUserRepository userRepo = userRepo;
        private readonly ICommonRepository commonRepo = commonRepo;
        private readonly INotificationAreaRepository notificationAreaRepo = notificationAreaRepo;
        private readonly IOrganizationRepository organizationRepo = organizationRepo;
        private readonly IUserRoleRepository userRoleRepo = userRoleRepo;
        private readonly IDesignationRepository designationRepo = designationRepo;
    


        private readonly ResponseMessage rm = new();

        public ResponseMessage UserAuthentication(AuthUser user)
        {
            try
            {
                AuthUser authUser = userRepo.UserAuthentication(user);
                if (authUser.UserAutoID > 0)
                {
                    if (authUser.Status != (int)UserStatusEnum.Active)
                    {
                        rm.Message = "No active user found";
                        rm.StatusCode = ReturnStatus.Failed;
                    }
                    else
                    {
                        rm.StatusCode = ReturnStatus.Success;
                        rm.ResponseObj = authUser;
                    }
                }
                else
                {
                    rm.Message = "Invalid UserID or Password";
                    rm.StatusCode = ReturnStatus.Failed;
                }
            }
            catch (Exception ex)
            {
                rm.Message = ex.Message;
                rm.StatusCode = ReturnStatus.Failed;
            }

            return rm;
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await userRepo.GetAll();
        }

        public async Task<Users?> GetByID(int id)
        {
            var user = await userRepo.GetByID(id);
            return user;
        }

        public async Task<Users?> Add(Users user)
        {
            var data = await userRepo.Add(user);
            return data;
        }

        public async Task<Users> Update(Users user)
        {
            var result = await userRepo.Update(user);
            var notificationArea = await notificationAreaRepo.GetByID((int)NotificationAreaEnum.UserLogin);
            await commonRepo.SendSMS(user.UserAutoID, user.MobileNo, "your number changed", notificationArea!, "");
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await userRepo.Delete(id);
            return response;
        }

        public async Task<IEnumerable<VMUsers>> GetAllByOrganizationID()
        {
            return await userRepo.GetAllByOrganizationID();
        }

        public async Task<IEnumerable<VMUsers>> GetAllByDepartmentID(int id)
        {
            return await userRepo.GetAllByDepartmentID(id);
        }

        public async Task<ResponseMessage> GetInitialData()
        {
            try
            {
                var lstOrganization = await organizationRepo.GetAll();
                var lstUserRole = await userRoleRepo.GetAll();
                var lstDesignation = await designationRepo.GetAll();
             

                rm.StatusCode = ReturnStatus.Success;
                rm.ResponseObj = new
                {
                    lstOrganization,
                    lstUserRole,
                    lstDesignation = lstDesignation.Where(x => x.IsActive == true).ToList(),
              
                };
            }
            catch (Exception ex)
            {
                rm.Message = ex.Message;
                rm.StatusCode = ReturnStatus.Failed;
            }

            return rm;
        }

        public async Task<ResponseMessage> ChangePassword(VMUsers user)
        {
            var data = await userRepo.ChangePassword(user);
            return data;
        }
    }
}
