using DotNet.ApplicationCore.DTOs;
using DotNet.Services.Repositories.Interfaces;
using DotNet.Services.Services.Interfaces;
using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;

namespace DotNet.Services.Services
{
    public class AttachmentsService(IAttachmentsRepository attachmentsRepository) : IAttachmentsService
    {
        private readonly IAttachmentsRepository _attachmentsRepository = attachmentsRepository;

        public async Task<ResponseMessage> GetAttachmentListByFileID(int id)
        {
            ResponseMessage response = new();
            var lstAttachments = await _attachmentsRepository.GetAttachmentListByFileID(id);
            response.ResponseObj = lstAttachments;
            response.StatusCode = ReturnStatus.Success;
            return response;
        }
    }
}
