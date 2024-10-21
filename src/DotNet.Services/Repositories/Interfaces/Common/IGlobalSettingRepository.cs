using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Repositories.Interfaces.Common
{
    public interface IGlobalSettingRepository
    {
        Task<IEnumerable<GlobalSetting>> GetAll();
        Task<List<GlobalSetting>> GetAllWithUserOrganization();
        Task<GlobalSetting?> GetByID(int id);
        Task<GlobalSetting> Update(GlobalSetting entity);
    }
}
