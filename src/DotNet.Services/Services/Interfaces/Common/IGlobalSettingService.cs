using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Services.Interfaces.Common
{
    public interface IGlobalSettingService
    {
        Task<IEnumerable<GlobalSetting>> GetAll();
        Task<List<GlobalSetting>> GetAllWithUserOrganization();
        Task<GlobalSetting?> GetByID(int id);
        //Task<GlobalSetting> Add(GlobalSetting entity);
        Task<GlobalSetting> Update(GlobalSetting entity);
        //Task<bool> Delete(int id);
        //Task<IEnumerable<GlobalSetting>> UpdateOrder(List<GlobalSetting> oList);
    }
}
