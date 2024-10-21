using System.Text;
using Microsoft.Extensions.Configuration;

using DotNet.ApplicationCore.Entities;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Services.Repositories.Interfaces;


namespace DotNet.Services.Repositories
{
    public class AttachmentsRepository(
        DotNetContext context,
        IConfiguration configuration,
        HttpClient httpClient
        ) : IAttachmentsRepository
    {
        private readonly DotNetContext _context = context;
        private readonly IConfiguration _configuration = configuration;
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<Attachments>> GetAttachmentListByFileID(int id)
        {
            var fileShowPath = _configuration.GetSection("FilePath:fileShowPath");

            List<Attachments> lstAttachments = [.._context.Attachments.Where(x => x.ReferenceID == id).OrderBy(x => x.ReferenceType)];

            foreach (Attachments attachment in lstAttachments)
            {
                var filePath = fileShowPath.Value + "/Attachments/" + attachment.AttachmentLink + "/" + attachment.AttachmentName;
                if (attachment.FileFormat == ".jpg" || attachment.FileFormat == ".jpeg" || attachment.FileFormat == ".png" || attachment.FileFormat == ".gif" || attachment.FileFormat == ".webp")
                {
                    attachment.AttachmentLink = "data:image/jpeg;base64," + ConvertImageURLToBase64(filePath);
                }
                else
                {
                    attachment.AttachmentLink = filePath;
                }
            }

            return await Task.FromResult(lstAttachments);
        }

        public string ConvertImageURLToBase64(string url)
        {
            StringBuilder _sb = new();

            var imgBytes = GetImage(url);

            if (imgBytes != null)
                _sb.Append(Convert.ToBase64String(imgBytes, 0, imgBytes.Length));

            return _sb.ToString();
        }

        private byte[]? GetImage(string url)
        {
            byte[]? buf = null;

            try
            {
                HttpRequestMessage request = new(HttpMethod.Get, url);
                HttpResponseMessage response = _httpClient.Send(request);
                Stream stream = response.Content.ReadAsStream();

                using (BinaryReader br = new(stream))
                {
                    var len = (int)stream.Length;
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Dispose();
            }
            catch (Exception exp)
            {
                exp.Message.ToString();
            }

            return buf;
        }
    }
}
