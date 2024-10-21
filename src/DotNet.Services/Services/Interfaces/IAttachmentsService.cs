using DotNet.ApplicationCore.DTOs;

namespace DotNet.Services.Services.Interfaces
{
    public interface IAttachmentsService
    {
        Task<ResponseMessage> GetAttachmentListByFileID(int type);
    }
}
