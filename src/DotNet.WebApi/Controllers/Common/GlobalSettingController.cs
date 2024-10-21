using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.DTOs;
using DotNet.Services.Services.Interfaces.Common;


namespace DotNet.WebApi.Controllers.Common
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalSettingController(IGlobalSettingService globalSettingSvc) : ControllerBase
    {
        private readonly IGlobalSettingService globalSettingSvc = globalSettingSvc;


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await globalSettingSvc.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("getByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await globalSettingSvc.GetByID(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(RequestMessage rm)
        {
            var GlobalSetting = JsonConvert.DeserializeObject<GlobalSetting>(rm.RequestObj.ToString());
            var response = await globalSettingSvc.Update(GlobalSetting);
            return Ok(response);
        }
    }
}
