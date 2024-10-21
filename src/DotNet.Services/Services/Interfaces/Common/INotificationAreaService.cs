using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Services.Interfaces.Common
{
    public interface INotificationAreaService //: ICommonInterface<NotificationArea>
    {
        Task<IEnumerable<NotificationArea>> GetAll();
        Task<NotificationArea?> GetByID(int id);
        Task<NotificationArea?> Add(NotificationArea entity);
        Task<NotificationArea> Update(NotificationArea entity);
        Task<bool> Delete(int id);
    }
}
