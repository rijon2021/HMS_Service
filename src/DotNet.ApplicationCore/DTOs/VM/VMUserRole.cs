namespace DotNet.ApplicationCore.DTOs.VM
{
    public class VMUserRole
    {
        public int UserRoleID { get; set; }
        public string UserRoleName { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDataRestricted { get; set; }
        public bool? AllowLocalMedia { get; set; }
        public int OrderNo { get; set; }
    }
}
