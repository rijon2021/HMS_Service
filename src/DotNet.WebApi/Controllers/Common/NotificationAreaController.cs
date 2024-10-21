using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using DotNet.Services.Services.Interfaces.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace DotNet.WebApi.Controllers.Common
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationAreaController(INotificationAreaService notificationAreaService, ILogger<NotificationAreaController> logger) : ControllerBase
    {
        private readonly INotificationAreaService _notificationAreaService = notificationAreaService;
        private readonly ILogger<NotificationAreaController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _notificationAreaService.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("getByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await _notificationAreaService.GetByID(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RequestMessage rm)
        {
            var NotificationArea = JsonConvert.DeserializeObject<NotificationArea>(rm.RequestObj.ToString());
            var response = await _notificationAreaService.Add(NotificationArea);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(RequestMessage rm)
        {
            var NotificationArea = JsonConvert.DeserializeObject<NotificationArea>(rm.RequestObj.ToString());
            var response = await _notificationAreaService.Update(NotificationArea);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _notificationAreaService.Delete(id);
            return Ok(response);
        }
    }
}
