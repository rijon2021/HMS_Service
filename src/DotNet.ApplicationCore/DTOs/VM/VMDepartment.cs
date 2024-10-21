namespace DotNet.ApplicationCore.DTOs
{
    public class VMDepartment
    {   
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameBangla { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
        public int OrganizationID { get; set; }
        public int? OrderNo { get; set; }
        public int ParentDepartmentID { get; set; }
        public string ParentDepartmentName { get; set; }
        public string ParentDepartmentNameBangla { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationNameBangla { get; set; }
    }
}
