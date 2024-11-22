using DotNet.Services.HMS.Repositories.Interfaces;
using DotNet.Services.HMS.Services.Interfaces;
using DotNet.Services.HMS.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.HMS.Services.Implementations
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<T> Add(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception($"Entity with ID {id} not found.");
            }
            _repository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }

}
