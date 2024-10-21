using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Newtonsoft.Json;

using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.DTOs;
using DotNet.Services.Services.Interfaces.Common;


namespace DotNet.WebApi.Controllers.Common
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController(IUserRoleService userRoleSvc) : ControllerBase
    {
        private readonly IUserRoleService userRoleSvc = userRoleSvc;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await userRoleSvc.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("getByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await userRoleSvc.GetByID(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RequestMessage rm)
        {
            var UserLevel = JsonConvert.DeserializeObject<UserRole>(rm.RequestObj.ToString());
            var response = await userRoleSvc.Add(UserLevel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(RequestMessage rm)
        {
            var UserLevel = JsonConvert.DeserializeObject<UserRole>(rm.RequestObj.ToString());
            var response = await userRoleSvc.Update(UserLevel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await userRoleSvc.Delete(id);
            return Ok(response);
        }

        [HttpPut("updateOrder")]
        public async Task<IActionResult> UpdateOrder(RequestMessage rm)
        {
            var userLevels = JsonConvert.DeserializeObject<List<UserRole>>(rm.RequestObj.ToString());
            var response = await userRoleSvc.UpdateOrder(userLevels);
            return Ok(response);
        }
    }
}
