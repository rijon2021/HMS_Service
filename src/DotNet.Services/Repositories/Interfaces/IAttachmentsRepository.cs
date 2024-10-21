using DotNet.ApplicationCore.Entities;

namespace DotNet.Services.Repositories.Interfaces
{

    public interface IAttachmentsRepository
    {
        Task<List<Attachments>> GetAttachmentListByFileID(int id);
    }
}
