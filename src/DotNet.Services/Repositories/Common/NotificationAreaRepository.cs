using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.Utils.Helper;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Services.Repositories.Interfaces.Common;


namespace DotNet.Services.Repositories.Common
{
    public class NotificationAreaRepository(
        DotNetContext dbContext,
        IHttpContextAccessor httpContextAccessor
            ) : INotificationAreaRepository
    {
        private readonly DotNetContext dbContext = dbContext;
        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

        public async Task<IEnumerable<NotificationArea>> GetAll()
        {
            var NotificationAreas = dbContext.NotificationAreas.ToList();
            return await Task.FromResult(NotificationAreas);
        }
        public async Task<NotificationArea?> GetByID(int id)
        {
            var result = dbContext.NotificationAreas.SingleOrDefault(x => x.NotificationAreaID == id);
            return await Task.FromResult(result);
        }
        public async Task<NotificationArea?> Add(NotificationArea notificationArea)
        {
            var userId = await httpContextAccessor!.HttpContext!.User.GetUserAutoIdFromClaimIdentity();
            dbContext.NotificationAreas.Add(notificationArea);
            dbContext.SaveChanges();

            return await GetByID(notificationArea.NotificationAreaID);
        }
        public async Task<NotificationArea> Update(NotificationArea notificationArea)
        {
            var data = await GetByID(notificationArea.NotificationAreaID) ?? throw new Exception();
            data.NotificationAreaName = notificationArea.NotificationAreaName;
            data.NotificationType = notificationArea.NotificationType;
            data.NotificationBody = notificationArea.NotificationBody;
            data.IsActive = notificationArea.IsActive;
            data.ExpireTime = notificationArea.ExpireTime;

            dbContext.NotificationAreas.Attach(data);
            dbContext.Entry(data).State = EntityState.Modified;
            dbContext.SaveChanges();
            return data;
        }
        public async Task<bool> Delete(int notificationAreaID)
        {
            var data = await GetByID(notificationAreaID);
            if (data != null)
            {
                dbContext.Entry(data).State = EntityState.Deleted;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

