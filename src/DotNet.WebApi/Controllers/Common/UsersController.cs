using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Newtonsoft.Json;

using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.DTOs.VM;
using DotNet.ApplicationCore.Entities;
using DotNet.Services.Services.Interfaces.Common;


namespace DotNet.WebApi.Controllers.Common
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userSvc) : ControllerBase
    {
        private readonly IUserService userSvc = userSvc;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await userSvc.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("getByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var user = await userSvc.GetByID(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RequestMessage rm)
        {
            var userObj = JsonConvert.DeserializeObject<Users>(rm.RequestObj.ToString());
            var user = await userSvc.Add(userObj);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Put(RequestMessage rm)
        {
            var user = JsonConvert.DeserializeObject<Users>(rm.RequestObj.ToString());
            var response = await userSvc.Update(user);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await userSvc.Delete(id);
            return Ok(response);
        }

        [HttpGet("getAllByOrganizationID")]
        public async Task<IActionResult> GetAllByOrganizationID()
        {
            var response = await userSvc.GetAllByOrganizationID();
            return Ok(response);
        }

        [HttpGet]
        [Route("getAllByDepartmentID/{id}")]
        public async Task<IActionResult> GetAllByDepartmentID(int id)
        {
            var response = await userSvc.GetAllByDepartmentID(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("getInitialData")]
        public async Task<IActionResult> GetInitialData()
        {
            var response = await userSvc.GetInitialData();
            return Ok(response);
        }

        [HttpPost]
        [Route("changePassword")]
        public async Task<IActionResult> ChangePassword(RequestMessage rm)
        {
            var user = JsonConvert.DeserializeObject<VMUsers>(rm.RequestObj.ToString());
            var response = await userSvc.ChangePassword(user);
            return Ok(response);
        }        
    }
}
