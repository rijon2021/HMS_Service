using DotNet.ApplicationCore.Entities;


namespace DotNet.Services.Services.Interfaces.Common
{
    public interface IDesignationService
    {
        Task<IEnumerable<Designation>> GetAll();
        Task<Designation?> GetByID(int id);
        Task<Designation?> Add(Designation entity);
        Task<Designation> Update(Designation entity);
        Task<bool> Delete(int id);
    }
}
