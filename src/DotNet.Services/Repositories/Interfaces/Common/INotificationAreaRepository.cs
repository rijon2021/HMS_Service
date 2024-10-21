using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Repositories.Interfaces.Common
{

    public interface INotificationAreaRepository //: ICommonRepository<NotificationArea>
    {
        Task<IEnumerable<NotificationArea>> GetAll();
        Task<NotificationArea?> GetByID(int id);
        Task<NotificationArea?> Add(NotificationArea entity);
        Task<NotificationArea> Update(NotificationArea entity);
        Task<bool> Delete(int id);
    }
}
