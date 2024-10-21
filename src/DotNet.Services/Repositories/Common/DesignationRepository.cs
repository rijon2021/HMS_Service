using Microsoft.EntityFrameworkCore;

using DotNet.ApplicationCore.Entities;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Services.Repositories.Interfaces.Common;


namespace DotNet.Services.Repositories.Common
{
    public class DesignationRepository(DotNetContext dbContext) : IDesignationRepository
    {
        private readonly DotNetContext dbContext = dbContext;

        public async Task<IEnumerable<Designation>> GetAll()
        {
            var Designations = dbContext.Designations.ToList();
            return await Task.FromResult(Designations);
        }

        public async Task<Designation?> GetByID(int id)
        {
            var result = dbContext.Designations.SingleOrDefault(x => x.DesignationID == id);
            return await Task.FromResult(result);
        }

        public async Task<Designation?> Add(Designation entity)
        {
            dbContext.Designations.Add(entity);
            dbContext.SaveChanges();

            return await GetByID(entity.DesignationID);
        }

        public async Task<Designation> Update(Designation entity)
        {
            var data = await GetByID(entity.DesignationID) ?? throw new Exception("Designation does not exist.");
            data.DesignationName = entity.DesignationName;
            data.DesignationNameBangla = entity.DesignationNameBangla;
            data.IsActive = entity.IsActive;
            data.OrderNo = entity.OrderNo;

            dbContext.Designations.Attach(data);
            dbContext.Entry(data).State = EntityState.Modified;
            dbContext.SaveChanges();

            return data;
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
    }
}
