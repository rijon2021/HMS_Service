using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNet.ApplicationCore.Entities
{
    [Table("PermissionUserRoleMaps", Schema = "core")]
    public class PermissionUserRoleMap
    {
        [Key]
        public int PermissionUserRoleMapID { get; set; }
        public int PermissionID { get; set; }
        public int UserRoleID { get; set; }
        public int OrganizationID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
      
    }
}
