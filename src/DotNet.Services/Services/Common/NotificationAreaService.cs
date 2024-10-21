﻿using DotNet.ApplicationCore.DTOs;
using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.Services.Services.Interfaces.Common;
using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Services.Common
{
    //GenericRepository<Users>,
    public class NotificationAreaService(
        INotificationAreaRepository NotificationAreaRepository
            ) : INotificationAreaService
    {
        private readonly INotificationAreaRepository _notificationAreaRepository = NotificationAreaRepository;
        readonly ResponseMessage rm = new();

        public async Task<IEnumerable<NotificationArea>> GetAll()
        {
            return await _notificationAreaRepository.GetAll();
        }
        public async Task<NotificationArea?> GetByID(int id)
        {
            var response = await _notificationAreaRepository.GetByID(id);
            return response;
        }
        public async Task<NotificationArea?> Add(NotificationArea notificationArea)
        {
            var data = await _notificationAreaRepository.Add(notificationArea);
            return data;
        }
        public async Task<NotificationArea> Update(NotificationArea notificationArea)
        {
            return await _notificationAreaRepository.Update(notificationArea);
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _notificationAreaRepository.Delete(id);
            return response;
        }
    }
}
