using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace DotNet.ApplicationCore.Utils.Enums
{
    public class GlobalEnum
    {
        public enum DataSchema
        {
            dbo = 1,
            core = 2,
            com = 3
        }

        public enum ReturnStatus
        {
            Success = 1,
            Failed = -1,
            Duplicate = 2,
            PendingOTPAuthentication = 3,
        }

        public enum UserRoleEnum
        {
            SuperAdmin = 1,
            SystemAdmin = 2,
            Admin = 3,
            User = 4,
            Employee = 11,
        }

        public enum PermissionType
        {
            Menu = 1,
            Button = 2,
            Role = 3,
        }

        public enum NotificationType
        {
            All = 0,
            SMS = 1,
            Email = 2,
            Push = 3,
        }

        public enum GeoFenceType
        {
            None = 0,
            All = 1
        }

        public enum DateType
        {
            ApprovalDate = 1,
            VisitDate,
        }

        public enum GlobalSettingsEnum
        {
            Login_Session_Time = 1,
            SMS_Base_Url = 2,
            Google_Map_Key = 3,
            Application_Migration_Max_Data_Upload = 4
        }

        public enum NotificationAreaEnum
        {
            UserRegistration = 1,
            UserLogin = 2,
        }

        public enum UserStatusEnum
        {
            Active = 1,
            Inactive = 2,
            Deleted = 3,
        }

        public enum OrganizationType
        {
            Govt = 1,
            Private = 2,
        }

        public enum ApplicationType
        {
            [Display(Name = "BC Case")]
            [Description("বি সি কেস")]
            BCCase = 1,

            [Display(Name = "Special Case")]
            [Description("স্পেশাল কেস")]
            SpecialCase = 2,

            [Display(Name = "LUC")]
            [Description("এল ইউ সি")]
            LUC = 3,

            [Display(Name = "Occupancy Certificate")]
            [Description("অকুপেন্সি সার্টিফিকেট")]
            OccupancyCertificate = 4,

            [Display(Name = "Others")]
            [Description("অন্যান্য")]
            Others = 5,

            [Display(Name = "NUC")]
            [Description("এন ইউ সি")]
            NUC = 6,
        }

        public enum LUCFormat
        {
            ATP = 1,
            Draftman = 2,
            GIS = 3
        }

        public enum AttachmentTypeEnum
        {
            Audio = 1,
            Image = 2,
            Video = 3,
            Map = 4,
            File = 5,
        }

        public enum ApplicationStatusEnum
        {
            [Display(Name = "Initialize")]
            Initialize = 1,

            [Display(Name = "Running")]
            Running = 2,

            [Display(Name = "Completed")]
            Completed = 3,
        }

        public enum InspectionFileType
        {
            [Display(Name = "Official Report")]
            OfficialReport = 1,

            [Display(Name = "Technical Report")]
            TechnicalReport = 2,
        }

        public enum InspectionRoleType
        {
            [Display(Name = "Officer In-Charge")]
            OfficerInCharge = 1,

            [Display(Name = "Assistant Officer")]
            AssistantOfficer = 2,
        }

        public enum BuildingType
        {
            [Display(Name = "Null")]
            Null = 1,
            [Display(Name = "Full")]
            Full = 2,
        }

        public enum LandType
        {
            [Display(Name = "Firming Land")]
            FirmingLand = 1,

            [Display(Name = "Living Land")]
            LivingLand = 2
        }

        public enum ElectricLineType
        {
            [Display(Name = "Low Tension")]
            LowTension = 1,

            [Display(Name = "High Tension")]
            HighTension = 2,
        }

        public enum DrainType
        {
            [Display(Name = "পাকা")]
            Paved = 1,

            [Display(Name = "কাঁচা")]
            Raw = 2,
        }

        public enum RoadNature
        {
            None = 1,
            Front = 2,
            Connecting = 3
        }

        public enum AuthorizationStatus
        {
            Authorized = 1,
            Unauthorized = 2
        }
    }
}
