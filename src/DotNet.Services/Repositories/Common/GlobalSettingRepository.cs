using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.Utils.Helper;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Services.Repositories.Interfaces.Common;


namespace DotNet.Services.Repositories.Common
{
    public class GlobalSettingRepository(DotNetContext dbContext, IHttpContextAccessor httpContextAccessor) : IGlobalSettingRepository
    {
        private readonly DotNetContext dbContext = dbContext;
        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

        public async Task<IEnumerable<GlobalSetting>> GetAll()
        {
            var GlobalSettings = dbContext.GlobalSettings.ToList();
            return await Task.FromResult(GlobalSettings);
        }
        
        public async Task<List<GlobalSetting>> GetAllWithUserOrganization()
        {
            var globalSettings = dbContext.GlobalSettings.ToList();
            return await Task.FromResult(globalSettings);
        }

        public async Task<GlobalSetting?> GetByID(int id)
        {
            var result = dbContext.GlobalSettings.SingleOrDefault(x => x.GlobalSettingID == id);
            return await Task.FromResult(result);
        }

        public async Task<GlobalSetting?> Add(GlobalSetting globalSetting)
        {
            var userId = await httpContextAccessor!.HttpContext!.User.GetUserAutoIdFromClaimIdentity();

            globalSetting.CreatedBy = Convert.ToInt32(userId);
            globalSetting.CreatedDate = DateTime.Now;
            globalSetting.UpdatedBy = Convert.ToInt32(userId);
            globalSetting.UpdatedDate = DateTime.Now;

            dbContext.GlobalSettings.Add(globalSetting);
            dbContext.SaveChanges();

            return await GetByID(globalSetting.GlobalSettingID);
        }

        public async Task<GlobalSetting> Update(GlobalSetting globalSetting)
        {
            var data = await GetByID(globalSetting.GlobalSettingID) ?? throw new Exception();
            data.GlobalSettingName = globalSetting.GlobalSettingName;
            data.Value = globalSetting.Value;
            data.ValueInString = globalSetting.ValueInString;
            data.IsActive = globalSetting.IsActive;
            data.OrganizationID = globalSetting.OrganizationID;

            dbContext.GlobalSettings.Attach(data);
            dbContext.Entry(data).State = EntityState.Modified;
            dbContext.SaveChanges();
            return data;
        }

        public async Task<bool> Delete(int globalSettingID)
        {
            var data = await GetByID(globalSettingID);
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
