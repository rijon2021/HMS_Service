using System.Collections.Generic;
using DotNet.ApplicationCore.Entities;

namespace DotNet.ApplicationCore.DTOs.Common
{
    public class PermissionDTO : Permission
    {
        public bool? HasChild { get; set; }
        public List<Permission> ChildList { get; set; }
    }
}
