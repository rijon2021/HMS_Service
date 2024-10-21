using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNet.ApplicationCore.Entities
{
    [Table("Designations", Schema = "core")]
    public class Designation
    {
        [Key]
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string DesignationNameBangla { get; set; }
        public bool IsActive { get; set; }
        public int OrderNo { get; set; }
    }
}
