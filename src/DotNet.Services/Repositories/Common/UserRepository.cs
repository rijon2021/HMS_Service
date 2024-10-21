using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.DTOs.VM;
using DotNet.ApplicationCore.Utils.Helper;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.ApplicationCore.Exceptions;

using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;


namespace DotNet.Services.Repositories.Common
{
    public class UserRepository(DotNetContext dbContext, IHttpContextAccessor httpContextAccessor) : IUserRepository
    {
        private readonly DotNetContext dbContext = dbContext;
        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

        public AuthUser UserAuthentication(AuthUser user)
        {
            string password = EncryptionHelper.Encrypt(user.Password);
            var dbUser = dbContext.Users.SingleOrDefault(x => string.Equals(x.UserID, user.UserID) && string.Equals(x.Password, password));
            AuthUser authUser = new();

            if (dbUser != null)
            {
                authUser.UserAutoID = dbUser.UserAutoID;
                authUser.UserID = dbUser.UserID;
                authUser.UserTypeID = dbUser.UserTypeID;
                authUser.OrganizationID = dbUser.OrganizationID;

                if (dbUser.DepartmentID == null)
                {
                    authUser.DepartmentID = 0;
                }
                else
                {
                    authUser.DepartmentID = (int)dbUser.DepartmentID;
                }

                authUser.UserFullName = dbUser.UserFullName;
                authUser.UserRoleID = dbUser.UserRoleID;
                authUser.UserImage = dbUser.UserImage;

                authUser.Status = dbUser.Status;
            }

            return authUser;
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            int organizationID = await httpContextAccessor!.HttpContext!.User.GetOrginzationIdFromClaimIdentity();
            int userAutoId = await httpContextAccessor.HttpContext.User.GetUserAutoIdFromClaimIdentity();
            var users = dbContext.Users.Where(x => x.OrganizationID == organizationID && x.Status != (int)UserStatusEnum.Deleted).ToList();
            return await Task.FromResult(users);
        }

        public async Task<Users?> GetByID(int id)
        {
            var result = dbContext.Users.SingleOrDefault(x => x.UserAutoID == id && x.Status != (int)UserStatusEnum.Deleted);
            return await Task.FromResult(result);
        }

        public async Task<Users?> GetByUserID(string userID)
        {
            var result = dbContext.Users.SingleOrDefault(x => x.UserID == userID);
            return await Task.FromResult(result);
        }

        public async Task<Users?> Add(Users user)
        {
            if (await GetByUserID(user.UserID) != null)
            {
                throw new DuplicateException("user already exists");
            }

            var userId = await httpContextAccessor!.HttpContext!.User.GetUserAutoIdFromClaimIdentity();
            user.Password = EncryptionHelper.Encrypt(user.Password);
            user.PasswordExpiryDate = DateTime.Now;
            user.CreatedBy = Convert.ToInt32(userId);
            user.CreatedDate = DateTime.Now;
            user.UpdatedBy = Convert.ToInt32(userId);
            user.UpdatedDate = DateTime.Now;

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return await GetByID(user.UserAutoID);
        }

        public async Task<Users> Update(Users user)
        {
            var dbUser = await GetByID(user.UserAutoID);
            var userId = await httpContextAccessor!.HttpContext!.User.GetUserAutoIdFromClaimIdentity();

            if (dbUser == null)
            {
                throw new Exception();
            }

            dbUser.UserID = user.UserID;
            dbUser.UserTypeID = user.UserTypeID;
            dbUser.UserRoleID = user.UserRoleID;
            dbUser.OrganizationID = user.OrganizationID;
            dbUser.DepartmentID = user.DepartmentID;
            dbUser.DesignationID = user.DesignationID;
            dbUser.UserFullName = user.UserFullName;
            dbUser.UserFullNameBangla = user.UserFullNameBangla;
            dbUser.MobileNo = user.MobileNo;
            dbUser.Address = user.Address;
            dbUser.PasswordExpiryDate = user.PasswordExpiryDate;
            dbUser.Status = user.Status;
            dbUser.Email = user.Email;
            dbUser.UserImage = user.UserImage;
            dbUser.Signature = user.Signature;
            dbUser.LastLatitude = user.LastLatitude;
            dbUser.LastLongitude = user.LastLongitude;
            dbUser.Is2FAauthenticationEnabled = user.Is2FAauthenticationEnabled;
            dbUser.NID = user.NID;
            dbUser.CanChangeOwnPassword = user.CanChangeOwnPassword;
            dbUser.MobileVerification = user.MobileVerification;
            dbUser.UpdatedBy = Convert.ToInt32(userId);
            dbUser.UpdatedDate = DateTime.Now;

            dbContext.Users.Attach(dbUser);
            dbContext.Entry(dbUser).State = EntityState.Modified;
            dbContext.SaveChanges();

            return dbUser;
        }

        public async Task<bool> Delete(int userAutoID)
        {
            var user = await GetByID(userAutoID);
            if (user != null)
            {
                user.Status = (int)UserStatusEnum.Deleted;
                dbContext.Entry(user).State = EntityState.Modified;
                dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<VMUsers>> GetAllByOrganizationID()
        {
            int organizationID = await httpContextAccessor!.HttpContext!.User.GetOrginzationIdFromClaimIdentity();
    
            int userAutoId = await httpContextAccessor.HttpContext.User.GetUserAutoIdFromClaimIdentity();
            var loginUser = dbContext.Users.SingleOrDefault(x => x.UserAutoID == userAutoId);
            var lstUser = dbContext.Users.Where(x => x.Status != (int)UserStatusEnum.Deleted);
            if (loginUser != null && loginUser.UserRoleID > 1)
            {
                lstUser = lstUser.Where(x => x.OrganizationID == organizationID);

            }

            var query =
                from user in lstUser.AsEnumerable()

                join designation in dbContext.Designations on user.DesignationID equals designation.DesignationID into designationMap
                from designationFiltered in designationMap.DefaultIfEmpty()

                select new VMUsers
                {
                    UserAutoID = user.UserAutoID,
                    UserID = user.UserID,
                    UserTypeID = user.UserTypeID,
                    UserRoleID = user.UserRoleID,
                    OrganizationID = user.OrganizationID,
                    DepartmentID = user.DepartmentID,
                    DesignationID = user.DesignationID,
                    UserFullName = user.UserFullName,
                    UserFullNameBangla = user.UserFullNameBangla,
                    MobileNo = user.MobileNo,
                    Address = user.Address,
                    PasswordExpiryDate = user.PasswordExpiryDate,
                    Status = user.Status,
                    Email = user.Email,
                    UserImage = user.UserImage,
                    Signature = user.Signature,
                    LastLatitude = user.LastLatitude,
                    LastLongitude = user.LastLongitude,
                    Is2FAauthenticationEnabled = user.Is2FAauthenticationEnabled,
                    NID = user.NID,
                    CanChangeOwnPassword = user.CanChangeOwnPassword,
                    MobileVerification = user.MobileVerification,
                    CreatedDate = user.CreatedDate,
                    CreatedBy = user.CreatedBy,
                    UpdatedDate = user.UpdatedDate,
                    UpdatedBy = user.UpdatedBy,
                    DesignationName = designationFiltered?.DesignationName ?? string.Empty,
                    DesignationNameBangla = designationFiltered?.DesignationNameBangla ?? string.Empty,
                };

            var retDataList = query.OrderBy(x => x.DepartmentID).ThenBy(x => x.UserFullName).ThenBy(x => x.DesignationID).ThenBy(x => x.CreatedDate).ToList();
            return await Task.FromResult(retDataList);
        }

        public async Task<IEnumerable<VMUsers>> GetAllByLoginUserDepartmentID()
        {
            int organizationID = await httpContextAccessor!.HttpContext!.User.GetOrginzationIdFromClaimIdentity();
            int userAutoId = await httpContextAccessor.HttpContext.User.GetUserAutoIdFromClaimIdentity();
            var loginUser = dbContext.Users.SingleOrDefault(x => x.UserAutoID == userAutoId);

            var datalist = GetUserList(organizationID, loginUser?.DepartmentID ?? 0);
            return await Task.FromResult(datalist);
        }

        public async Task<IEnumerable<VMUsers>> GetAllByDepartmentApplicationMap()
        {
            int organizationID = await httpContextAccessor!.HttpContext!.User.GetOrginzationIdFromClaimIdentity();
            var query = from user in dbContext.Users.AsEnumerable()

                        join designation in dbContext.Designations on user.DesignationID equals designation.DesignationID into designationMap
                        from designationFiltered in designationMap.DefaultIfEmpty()
                        where user.OrganizationID == organizationID &&
                              user.Status == 1 && (
                                user.DesignationID == 1004 ||
                                user.DesignationID == 1011
                              )
                        orderby user.DepartmentID
                        select new VMUsers
                        {
                            UserAutoID = user.UserAutoID,
                            UserID = user.UserID,
                            UserTypeID = user.UserTypeID,
                            UserRoleID = user.UserRoleID,
                            OrganizationID = user.OrganizationID,
                            DepartmentID = user.DepartmentID,
                            DesignationID = user.DesignationID,
                            UserFullName = user.UserFullName,
                            UserFullNameBangla = user.UserFullNameBangla,
                            MobileNo = user.MobileNo,
                            Address = user.Address,
                            PasswordExpiryDate = user.PasswordExpiryDate,
                            Status = user.Status,
                            Email = user.Email,
                            UserImage = user.UserImage,
                            Signature = user.Signature,
                            LastLatitude = user.LastLatitude,
                            LastLongitude = user.LastLongitude,
                            Is2FAauthenticationEnabled = user.Is2FAauthenticationEnabled,
                            NID = user.NID,
                            CanChangeOwnPassword = user.CanChangeOwnPassword,
                            MobileVerification = user.MobileVerification,
                            CreatedDate = user.CreatedDate,
                            CreatedBy = user.CreatedBy,
                            UpdatedDate = user.UpdatedDate,
                            UpdatedBy = user.UpdatedBy,
        
                            DesignationName = designationFiltered?.DesignationName ?? string.Empty,
                            DesignationNameBangla = designationFiltered?.DesignationNameBangla ?? string.Empty,
                        };

            return await Task.FromResult(query.ToList());
        }

        public async Task<IEnumerable<VMUsers>> GetAllByDepartmentID(int id)
        {
            int organizationID = await httpContextAccessor!.HttpContext!.User.GetOrginzationIdFromClaimIdentity();
            var users = dbContext.Users.Where(x => x.OrganizationID == organizationID).ToList();

            var datalist = GetUserList(organizationID, id);
            return await Task.FromResult(datalist);
        }

        public IEnumerable<VMUsers> GetUserList(int organizationID, int departmentID)
        {
            var users = dbContext.Users.Where(x => x.OrganizationID == organizationID && x.Status == (int)UserStatusEnum.Active).ToList();

            var query =
                from user in dbContext.Users.Where(x => x.OrganizationID == organizationID && x.Status == (int)UserStatusEnum.Active).AsEnumerable()

                join designation in dbContext.Designations on user.DesignationID equals designation.DesignationID into designationMap
                from designationFiltered in designationMap.DefaultIfEmpty()

                where departmentID == user.DepartmentID

                select new VMUsers
                {
                    UserAutoID = user.UserAutoID,
                    UserID = user.UserID,
                    UserTypeID = user.UserTypeID,
                    UserRoleID = user.UserRoleID,
                    OrganizationID = user.OrganizationID,
                    DepartmentID = user.DepartmentID,
                    DesignationID = user.DesignationID,
                    UserFullName = user.UserFullName,
                    UserFullNameBangla = user.UserFullNameBangla,
                    MobileNo = user.MobileNo,
                    Address = user.Address,
                    PasswordExpiryDate = user.PasswordExpiryDate,
                    Status = user.Status,
                    Email = user.Email,
                    UserImage = user.UserImage,
                    Signature = user.Signature,
                    LastLatitude = user.LastLatitude,
                    LastLongitude = user.LastLongitude,
                    Is2FAauthenticationEnabled = user.Is2FAauthenticationEnabled,
                    NID = user.NID,
                    CanChangeOwnPassword = user.CanChangeOwnPassword,
                    MobileVerification = user.MobileVerification,
                    CreatedDate = user.CreatedDate,
                    CreatedBy = user.CreatedBy,
                    UpdatedDate = user.UpdatedDate,
                    UpdatedBy = user.UpdatedBy,
       
                    DesignationName = designationFiltered?.DesignationName ?? string.Empty,
                    DesignationNameBangla = designationFiltered?.DesignationNameBangla ?? string.Empty,
                };

            var retDataList = query.OrderBy(x => x.UserFullName).ThenBy(x => x.CreatedDate).ToList();
            return retDataList;
        }

        public async Task<ResponseMessage> ChangePassword(VMUsers user)
        {
            ResponseMessage response = new();

            try
            {
                string dbPass = EncryptionHelper.Encrypt(user.Password);
                var dbUser = await dbContext.Users.SingleOrDefaultAsync(x => x.UserAutoID == user.UserAutoID && x.Password == dbPass) ?? throw new Exception("No User found");
                if (user.NewPassword.Length < 5)
                {
                    throw new Exception("Passeord will be atleast 5 char");
                }
                if (user.NewPassword.Contains(' ') || user.NewPassword.Contains('.'))
                {
                    throw new Exception("Password can't contain whitespace or dot");
                }
                if (user.NewPassword != user.ConfirmPassword)
                {
                    throw new Exception("Passeord does not match");
                }
                if (user.Password == user.NewPassword)
                {
                    throw new Exception("Old Password and new password can not be same");
                }

                dbUser.Password = EncryptionHelper.Encrypt(user.NewPassword);
                dbUser.PasswordExpiryDate = DateTime.Now.AddMonths(12);

                dbContext.Users.Attach(dbUser);
                dbContext.Entry(dbUser).State = EntityState.Modified;
                dbContext.SaveChanges();

                response.Message = "Password Updated";
                response.StatusCode = ReturnStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCode = ReturnStatus.Failed;

            }

            return response;
        }
    }
}
