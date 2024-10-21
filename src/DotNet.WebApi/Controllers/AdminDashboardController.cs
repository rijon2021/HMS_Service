using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Newtonsoft.Json;

using DotNet.ApplicationCore.DTOs;
using DotNet.ApplicationCore.DTOs.Common;
using DotNet.Services.Services.Interfaces;


namespace DotNet.WebApi.Controllers.Common
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController(IAdminDashboardService adminDashboardSvc) : ControllerBase
    {
        private readonly IAdminDashboardService adminDashboardSvc = adminDashboardSvc;

        //[HttpGet]
        //[Route("getAdminDashboard")]
        //public async Task<IActionResult> GetAdminDashboard()
        //{
        //    var response = await adminDashboardSvc.GetAdminDashboard();
        //    return Ok(response);
        //}

        //[HttpGet]
        //[Route("getFileListByFileType/{type}")]
        //public async Task<IActionResult> GetFileListByFileType(int type)
        //{
        //    var response = await adminDashboardSvc.GetFileListByFileType(type);
        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("getFileListByTypeVisitedUser")]
        //public async Task<IActionResult> GetFileListByTypeVisitedUser(RequestMessage rm)
        //{
        //    QueryObject queryObject = JsonConvert.DeserializeObject<QueryObject>(rm.RequestObj.ToString());
        //    var response = await adminDashboardSvc.GetFileListByTypeVisitedUser(queryObject);
        //    return Ok(response);
        //}
    }
}
