using DotNet.Services.Repositories.Interfaces.Common;

namespace DotNet.Services.Repositories.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IPermissionRepository Permissions { get; }
        IUserRoleRepository UserLevels { get; }
        int Save();
    }
}
