namespace DotNet.ApplicationCore.DTOs.VM
{
    public class VMAttachmentWithLocation
    {
        public int ApplicationFileMasterID { get; set; }
        public int? InspectionFileType { get; set; }
        public dynamic AttachmentType { get; set; }
#nullable enable
        public AttachmentWithLocation[]? Files { get; set; }
#nullable disable
    }

    public class AttachmentWithLocation
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
