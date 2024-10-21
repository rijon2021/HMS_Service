namespace DotNet.ApplicationCore.DTOs.VM
{
    public class VMAttachments
    {
        public string FileFormat { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentLink { get; set; }
        public string FileContent { get; set; }
        public int AttachementTypeID { get; set; }
        public int ApplicationTypeID { get; set; }
    }
}
