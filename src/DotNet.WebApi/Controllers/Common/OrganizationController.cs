﻿using DotNet.ApplicationCore.DTOs;
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
    public class OrganizationController(IOrganizaionService organizaionService, ILogger<OrganizationController> logger) : ControllerBase
    {
        private readonly IOrganizaionService _organizaionService = organizaionService;
        private readonly ILogger<OrganizationController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _organizaionService.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("getByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await _organizaionService.GetByID(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RequestMessage rm)
        {
            var organization = JsonConvert.DeserializeObject<Organization>(rm.RequestObj.ToString());
            var response = await _organizaionService.Add(organization);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(RequestMessage rm)
        {
            var organization = JsonConvert.DeserializeObject<Organization>(rm.RequestObj.ToString());
            var response = await _organizaionService.Update(organization);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _organizaionService.Delete(id);
            return Ok(response);
        }
        [HttpGet]
        [Route("getInitialData")]
        public async Task<IActionResult> GetInitialData()
        {
            var response = await _organizaionService.GetInitialData();
            return Ok(response);
        }

    }
}
