using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.DTOs.Common;
using DotNet.ApplicationCore.DTOs.VM;
using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.Services.Services.Infrastructure;
using DotNet.Services.Services.Interfaces.Common;

using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;


namespace DotNet.WebApi.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController(
        ITokenService tokenSvc,
        IUserService userSvc,
        IUserRoleService userRoleSvc,
        IPermissionService permSvc,
        IGlobalSettingService globalSettingSvc,
      //  IApplicationTypeRepository appTypeRepo,
        IMapper mapper
    ) : ControllerBase
    {
        private readonly IUserService userSvc = userSvc;
        private readonly IUserRoleService userRoleSvc = userRoleSvc;
        private readonly IPermissionService permSvc = permSvc;
        private readonly IGlobalSettingService globalSettingSvc = globalSettingSvc;
        private readonly ITokenService tokenSvc = tokenSvc;
     //   private readonly IApplicationTypeRepository appTypeRepo = appTypeRepo;
        private readonly IMapper mapper = mapper;


        [HttpPost("authenticate"), AllowAnonymous]
        public async Task<IActionResult> Authenticate(RequestMessage rm)
        {
            var user = JsonConvert.DeserializeObject<AuthUser>(rm.RequestObj.ToString());
            ResponseMessage resMes = userSvc.UserAuthentication(user);

            AuthUser authUser = (AuthUser)resMes.ResponseObj;
            if (authUser == null || authUser.UserAutoID == 0)
            {
                resMes.StatusCode = ReturnStatus.Failed;
                return await Task.FromResult(Ok(resMes));
            }

            authUser.TokenResult = tokenSvc.BuildToken(authUser);

            var lstPermission = await permSvc.GetListByUserRoleID(authUser.UserRoleID);
            lstPermission = permSvc.MakeListWithChild((List<Permission>)lstPermission);

            var userRole = await userRoleSvc.GetByID(authUser.UserRoleID);
            authUser.UserRole = mapper.Map<VMUserRole>(userRole);
            authUser.Permissions = (List<PermissionDTO>)lstPermission;
            authUser.GlobalSettings = await globalSettingSvc.GetAllWithUserOrganization();

          //  authUser.ApplicationTypes = (List<ApplicationTypes>)await appTypeRepo.GetAll(authUser.UserAutoID, authUser.UserRoleID);

            resMes.ResponseObj = authUser;
            resMes.StatusCode = ReturnStatus.Success;

            return await Task.FromResult(Ok(resMes));
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginRequest _user)
        {
            AuthUser user = new AuthUser{UserID= _user.UserName, Password=_user.Password };
         
     
            
            ResponseMessage resMes = userSvc.UserAuthentication(user);

            AuthUser authUser = (AuthUser)resMes.ResponseObj;
            if (authUser == null || authUser.UserAutoID == 0)
            {
                resMes.StatusCode = ReturnStatus.Failed;
                return await Task.FromResult(Ok(resMes));
            }

            authUser.TokenResult = tokenSvc.BuildToken(authUser);

            var lstPermission = await permSvc.GetListByUserRoleID(authUser.UserRoleID);
            lstPermission = permSvc.MakeListWithChild((List<Permission>)lstPermission);

            var userRole = await userRoleSvc.GetByID(authUser.UserRoleID);
            authUser.UserRole = mapper.Map<VMUserRole>(userRole);
            authUser.Permissions = (List<PermissionDTO>)lstPermission;
            authUser.GlobalSettings = await globalSettingSvc.GetAllWithUserOrganization();

            //  authUser.ApplicationTypes = (List<ApplicationTypes>)await appTypeRepo.GetAll(authUser.UserAutoID, authUser.UserRoleID);

            resMes.ResponseObj = authUser;
            resMes.StatusCode = ReturnStatus.Success;

            return await Task.FromResult(Ok(resMes));
        }
    }
}
