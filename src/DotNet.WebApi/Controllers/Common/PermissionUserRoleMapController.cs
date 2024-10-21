﻿using DotNet.ApplicationCore.DTOs;
using DotNet.Services.Services.Interfaces.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet.WebApi.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionUserRoleMapController(IPermissionUserRoleMapService userService, ILogger<PermissionUserRoleMapController> logger) : ControllerBase
    {
        private readonly IPermissionUserRoleMapService _permissionUserRoleMapService = userService;
        private readonly ILogger<PermissionUserRoleMapController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _permissionUserRoleMapService.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("getByUserRoleID/{id}")]
        public async Task<IActionResult> GetByUserRoleID(int id)
        {
            var response = await _permissionUserRoleMapService.GetListByUserRoleID(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePermissionList(RequestMessage rm)
        {
            var lstVMPermissionUserRoleMap = JsonConvert.DeserializeObject<List<VMPermissionUserRoleMap>>(rm.RequestObj.ToString());
            var response = await _permissionUserRoleMapService.UpdatePermissionList(lstVMPermissionUserRoleMap);
            return Ok(response);
        }
        [HttpGet]
        [Route("getInitialData")]
        public async Task<IActionResult> GetInitialData()
        {
            var response = await _permissionUserRoleMapService.GetInitialData();
            return Ok(response);
        }
    }
}
