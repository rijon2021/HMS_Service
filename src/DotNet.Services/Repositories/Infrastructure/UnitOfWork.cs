using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Services.Repositories.Interfaces.Common;

namespace DotNet.Services.Repositories.Infrastructure
{
    public class UnitOfWork(
        DotNetContext dotnetContext,
        IUserRepository userRepository,
        IPermissionRepository permissionRepository,
        IUserRoleRepository userLevelRepository
            ) : IUnitOfWork
    {
        private readonly DotNetContext _dotnetContext = dotnetContext;
        public IUserRepository Users { get; } = userRepository;
        public IPermissionRepository Permissions { get; } = permissionRepository;
        public IUserRoleRepository UserLevels { get; } = userLevelRepository;

        public int Save()
        {
            return _dotnetContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dotnetContext.Dispose();
            }
        }

    }
}
