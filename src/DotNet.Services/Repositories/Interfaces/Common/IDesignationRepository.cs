using DotNet.ApplicationCore.Entities;


namespace DotNet.Services.Repositories.Interfaces.Common
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<Designation>> GetAll();
        Task<Designation?> GetByID(int id);
        Task<Designation?> Add(Designation entity);
        Task<Designation> Update(Designation entity);
        Task<bool> Delete(int id);
    }
}
