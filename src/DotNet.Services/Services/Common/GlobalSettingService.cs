using DotNet.ApplicationCore.Entities;
using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.Services.Services.Interfaces.Common;


namespace DotNet.Services.Services.Common
{
    public class GlobalSettingService(IGlobalSettingRepository GlobalSettingRepository) : IGlobalSettingService
    {
        private readonly IGlobalSettingRepository _globalSettingRepository = GlobalSettingRepository;


        public async Task<IEnumerable<GlobalSetting>> GetAll()
        {
            return await _globalSettingRepository.GetAll();
        }

        public async Task<List<GlobalSetting>> GetAllWithUserOrganization()
        {
            return await _globalSettingRepository.GetAllWithUserOrganization();
        }

        public async Task<GlobalSetting?> GetByID(int id)
        {
            var response = await _globalSettingRepository.GetByID(id);
            return response;
        }

        //public async Task<UserLevel> Add(GlobalSetting globalSetting)
        //{
        //    var data = await _globalSettingRepository.Add(globalSetting);
        //    _dotnetContext.SaveChanges();
        //    return data;
        //}

        public async Task<GlobalSetting> Update(GlobalSetting globalSetting)
        {
            return await _globalSettingRepository.Update(globalSetting);
        }

        //public async Task<bool> Delete(int id)
        //{
        //    var response = await _globalSettingRepository.Delete(id);
        //    return response;
        //}
    }
}
