using DotNet.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace DotNet.WebApi.Controllers.Common
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController(IAttachmentsService districtService) : ControllerBase
    {
        private readonly IAttachmentsService _attachmentsService = districtService;

        [HttpGet]
        [Route("getAttachmentListByFileID/{id}")]
        public async Task<IActionResult> GetAttachmentListByFileID(int id)
        {
            var response = await _attachmentsService.GetAttachmentListByFileID(id);
            return Ok(response);
        }
    }
}
