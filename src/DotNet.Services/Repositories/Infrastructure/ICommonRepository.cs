
using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Repositories.Infrastructure
{
    public interface ICommonRepository
    {
        Task<bool> SendSMS(int UserID, string recipientMobileNo, string messageBody, NotificationArea notificationArea, string otp);
           
        //Task<IEnumerable<T>> GetAll();
        //Task<T> GetByID(int id);
        //Task<T> Add(T entity);
        //Task<T> Update(T entity);
        //Task<bool> Delete(int id);
        //Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
    }
}