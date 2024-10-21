using Microsoft.AspNetCore.Http;
using DotNet.ApplicationCore.Utils.Helper;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.ApplicationCore.Entities;
using DotNet.Services.Repositories.Interfaces.Common;
using Microsoft.EntityFrameworkCore;


namespace DotNet.Services.Repositories.Common
{
    public class PermissionRepository(
        DotNetContext dbContext,
        IHttpContextAccessor httpContextAccessor
        ) : IPermissionRepository
    {
        private readonly DotNetContext dbContext = dbContext;
        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

        public async Task<IEnumerable<Permission>> GetAll()
        {
            var permissions = dbContext.Permissions.OrderBy(x => x.OrderNo).ToList();
            return await Task.FromResult(permissions);
        }

        public async Task<Permission?> GetByID(int id)
        {
            var result = dbContext.Permissions.SingleOrDefault(x => x.PermissionID == id);
            return await Task.FromResult(result);
        }

        public async Task<Permission?> Add(Permission permission)
        {
            var userId = await httpContextAccessor!.HttpContext!.User.GetUserAutoIdFromClaimIdentity();

            permission.CreatedBy = Convert.ToInt32(userId);
            permission.CreatedDate = DateTime.Now;
            permission.UpdatedBy = Convert.ToInt32(userId);
            permission.UpdatedDate = DateTime.Now;

            dbContext.Permissions.Add(permission);
            dbContext.SaveChanges();

            return await GetByID(permission.PermissionID);
        }

        public async Task<Permission> Update(Permission permission)
        {
            var data = await GetByID(permission.PermissionID);
            var userId = await httpContextAccessor!.HttpContext!.User.GetUserAutoIdFromClaimIdentity();

            if (data == null)
            {
                throw new Exception();
            }

            data.PermissionName = permission.PermissionName;
            data.DisplayName = permission.DisplayName;
            data.ParentPermissionID = permission.ParentPermissionID;
            data.IsActive = permission.IsActive;
            data.IsVisible = permission.IsVisible;
            data.IconName = permission.IconName;
            data.RoutePath = permission.RoutePath;
            data.PermissionType = permission.PermissionType;
            data.OrderNo = permission.OrderNo;
            data.UpdatedBy = Convert.ToInt32(userId);
            data.UpdatedDate = DateTime.Now;

            dbContext.Permissions.Attach(data);
            dbContext.Entry(data).State = EntityState.Modified;
            dbContext.SaveChanges();

            return data;
        }

        public async Task<bool> Delete(int permissionID)
        {
            var data = await GetByID(permissionID);
            if (data != null)
            {
                dbContext.Entry(data).State = EntityState.Deleted;
                dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Permission>> UpdateOrder(List<Permission> oList)
        {
            var dbList = await GetAll();
            foreach (Permission permission in dbList)
            {
                var obj = oList.SingleOrDefault(x => x.PermissionID == permission.PermissionID);
                if (obj != null)
                {
                    permission.OrderNo = obj.OrderNo;
                    dbContext.Permissions.Attach(permission);
                    dbContext.Entry(permission).State = EntityState.Modified;
                }
            }

            dbContext.SaveChanges();
            var dbList_updated = await GetAll();
            return dbList_updated;
        }

        public async Task<IEnumerable<Permission>> GetListByUserRoleID(int id)
        {
            var lstPermission = dbContext.Permissions.Where(x => x.IsActive).ToList();

            if (id > 1)
            {
                var lstMap = dbContext.PermissionUserRoleMaps.Where(x => x.UserRoleID == id).ToList();
                IEnumerable<string> mapIDs = lstMap.Select(x => x.PermissionID.ToString()).ToList();
                lstPermission = [..dbContext.Permissions.Where(x => mapIDs.Contains(x.PermissionID.ToString()) && x.IsActive)];
            }

            return await Task.FromResult(lstPermission.OrderBy(x => x.OrderNo).ToList());
        }
    }
}
