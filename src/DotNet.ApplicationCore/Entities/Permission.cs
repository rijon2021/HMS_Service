﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;


namespace DotNet.ApplicationCore.Entities
{
    [Table("Permissions", Schema = "core")]
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public string DisplayName { get; set; }
        public int? ParentPermissionID { get; set; }
        public bool IsActive { get; set; }
        public bool? IsVisible { get; set; }
        public string IconName { get; set; }
        public string RoutePath { get; set; }
        public PermissionType PermissionType { get; set; }
        public int OrderNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        [NotMapped]
        public string PermissionTypeStr
        {
            get
            {
                return PermissionType.ToString();
            }
        }
    }
}
