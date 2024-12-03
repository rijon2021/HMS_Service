using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.Entities.HMS
{
    public abstract class BaseEntity
    {
        public byte Status { get; set; } = 1; // Default value set to 1. 1=Active,0=Inactive,if need others then use 2,3,4 etc
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } 
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
