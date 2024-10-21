using Microsoft.AspNetCore.Http;
using DotNet.ApplicationCore.Utils.Helper;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.ApplicationCore.Entities;
using DotNet.Services.Repositories.Interfaces.Common;
using Microsoft.EntityFrameworkCore;


namespace DotNet.Services.Repositories.Common
{
    public class UserRoleRepository(DotNetContext dbContext, IHttpContextAccessor httpContextAccessor) : IUserRoleRepository
    {
        private readonly DotNetContext dbContext = dbContext;
        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

        public async Task<IEnumerable<UserRole>> GetAll()
        {
            var entities = dbContext.UserRoles.OrderBy(x => x.OrderNo).ToList();
            return await Task.FromResult(entities);
        }

        public async Task<UserRole?> GetByID(int id)
        {
            var entity = dbContext.UserRoles.SingleOrDefault(x => x.UserRoleID == id);
            return await Task.FromResult(entity);
        }

        public async Task<UserRole?> Add(UserRole entity)
        {
            var userId = await httpContextAccessor!.HttpContext!.User.GetUserAutoIdFromClaimIdentity();
            entity.CreatedBy = userId;
            entity.CreatedDate = DateTime.Now;

            dbContext.UserRoles.Add(entity);
            dbContext.SaveChanges();

            return await GetByID(entity.UserRoleID);
        }

        public async Task<UserRole> Update(UserRole entity)
        {
            var updatingEntity = await GetByID(entity.UserRoleID) ?? throw new Exception("User role does not exist.");

            updatingEntity.UserRoleName = entity.UserRoleName;
            updatingEntity.IsActive = entity.IsActive;
            updatingEntity.IsDataRestricted = entity.IsDataRestricted;
            updatingEntity.OrderNo = entity.OrderNo;
            updatingEntity.AllowLocalMedia = entity.AllowLocalMedia;

            dbContext.UserRoles.Attach(updatingEntity);
            dbContext.Entry(updatingEntity).State = EntityState.Modified;
            dbContext.SaveChanges();

            return updatingEntity;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await GetByID(id);
            if (data != null)
            {
                dbContext.Entry(data).State = EntityState.Deleted;
                dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<UserRole>> UpdateOrder(List<UserRole> entities)
        {
            var updatingEntities = await GetAll();
            foreach (UserRole entity in updatingEntities)
            {
                var obj = entities.SingleOrDefault(x => x.UserRoleID == entity.UserRoleID);
                if (obj != null)
                {
                    entity.OrderNo = obj.OrderNo;
                    dbContext.UserRoles.Attach(entity);
                    dbContext.Entry(entity).State = EntityState.Modified;
                }
            }

            dbContext.SaveChanges();

            var updatedEntities = await GetAll();
            return updatedEntities;
        }
    }
}
