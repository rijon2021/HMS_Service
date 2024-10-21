using DotNet.ApplicationCore.Utils.Enums;
using System;
using System.Collections.Generic;
using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;


namespace DotNet.ApplicationCore.DTOs.VM
{
    public class VMAdminDashboard
    {
        public List<VMAdminDashboardFileTypeWise> AdminDashboardFileTypeWiseList { get; set; }
    }

    public class VMAdminDashboardFileTypeWise
    {
        public ApplicationType ApplicationType { get; set; }
        public int TotalFile { get; set; }
        public int Visited { get; set; }
        public string ColorCode { get; set; }
        public string Icon { get; set; }
        public string Border { get; set; }
        public string ApplicationTypeName
        {
            get
            {
                return ApplicationType.GetEnumDisplayName();
            }
        }
        public string ApplicationTypeDescription
        {
            get
            {
                return ApplicationType.GetEnumDescription();
            }
        }
    }

    public class VMAdminDashboardFileUserWise
    {
        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserFullNameBangla { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameBangla { get; set; }
        public int TotalFile { get; set; }
        public int Visited { get; set; }
    }

    public class VMAdminDashboardFileListUserWise
    {
        public string RefNo { get; set; }
        public string ApplicantName { get; set; }
        public int? ThanaID { get; set; }
        public string ThanaName { get; set; }
        public int? MouzaID { get; set; }
        public string MouzaName { get; set; }
        public bool? IsVisited { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? VisitDate { get; set; }
    }
}