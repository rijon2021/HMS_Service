using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNet.ApplicationCore.Entities
{
    [Table("Attachments", Schema = "com")]
    public class Attachments
    {
        [Key]
        public int AttachmentID { get; set; }
        public int? ReferenceType { get; set; }
        public int ReferenceID { get; set; }
        public int AttachementTypeID { get; set; }
        public string FileFormat { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentLink { get; set; }
        public string FileContent { get; set; }
        public string Notes { get; set; }
        public int Status { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
