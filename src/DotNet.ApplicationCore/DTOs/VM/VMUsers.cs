using System;


namespace DotNet.ApplicationCore.DTOs.VM
{
    public class VMUsers
    {
        public int UserAutoID { get; set; }
        public string UserID { get; set; }
        public int UserTypeID { get; set; }
        public int UserRoleID { get; set; }
        public int OrganizationID { get; set; }
        public int? DepartmentID { get; set; }
        public int? DesignationID { get; set; }
        public string UserFullName { get; set; }
        public string UserFullNameBangla { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public int Status { get; set; }
        public string Email { get; set; }
        public byte[] UserImage { get; set; }
        public byte[] Signature { get; set; }
        public double? LastLatitude { get; set; }
        public double? LastLongitude { get; set; }
        public bool? Is2FAauthenticationEnabled { get; set; }
        public string NID { get; set; }
        public bool? CanChangeOwnPassword { get; set; }
        public bool? MobileVerification { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        //public string DepartmentName { get; set; }
        //public string DepartmentNameBangla { get; set; }
        public string DesignationName { get; set; }
        public string DesignationNameBangla { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public int? ApplicationTypeID { get; set; }
    }
}
