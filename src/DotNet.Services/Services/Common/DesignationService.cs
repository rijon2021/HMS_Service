using DotNet.ApplicationCore.Entities;
using DotNet.Services.Services.Interfaces.Common;
using DotNet.Services.Repositories.Interfaces.Common;


namespace DotNet.Services.Services.Common
{
    public class DesignationService(IDesignationRepository designationRepo) : IDesignationService
    {
        private readonly IDesignationRepository designationRepo = designationRepo;

        public async Task<IEnumerable<Designation>> GetAll()
        {
            return await designationRepo.GetAll();
        }

        public async Task<Designation?> GetByID(int id)
        {
            var response = await designationRepo.GetByID(id);
            return response;
        }

        public async Task<Designation?> Add(Designation Designation)
        {
            var data = await designationRepo.Add(Designation);
            return data;
        }
        
        public async Task<Designation> Update(Designation Designation)
        {
            return await designationRepo.Update(Designation);
        }
        
        public async Task<bool> Delete(int id)
        {
            var response = await designationRepo.Delete(id);
            return response;
        }
    }
}
