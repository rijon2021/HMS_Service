using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.Entities;
using DotNet.Services.Services.Interfaces.Common;


namespace DotNet.WebApi.Controllers.Common
{
    [Authorize, Route("api/[controller]"), ApiController]
    public class DesignationController(IDesignationService designationSvc) : ControllerBase
    {
        private readonly IDesignationService designationSvc = designationSvc;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await designationSvc.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("getByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await designationSvc.GetByID(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RequestMessage requestMsg)
        {
            var entity = JsonConvert.DeserializeObject<Designation>(requestMsg.RequestObj.ToString());
            var response = await designationSvc.Add(entity);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(RequestMessage requestMsg)
        {
            var entity = JsonConvert.DeserializeObject<Designation>(requestMsg.RequestObj.ToString());
            var response = await designationSvc.Update(entity);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await designationSvc.Delete(id);
            return Ok(response);
        }
    }
}
