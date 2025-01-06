using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.Entities.HMS
{
    [Table("BedAssignHistories", Schema = "core")]
    public class BedAssignHistory:BaseEntity
    {
        [Key]
        public int AssignmentId { get; set; }  // Primary Key
        public int MemberId { get; set; }      // Foreign Key to Member
        public int BedId { get; set; }         // Foreign Key to Bed
        public int RoomId { get; set; }        // Foreign Key to Room
        public int BranchId { get; set; }      // Foreign Key to Branch
        public int AssignedBy { get; set; }    // Foreign Key to Staff (Assigned By)
        public DateTime AssignedAt { get; set; } // Date and time of assignment
        public int? UnassignedBy { get; set; }  // Foreign Key to Staff (Unassigned By, nullable)
        public DateTime? UnassignedAt { get; set; } // Date and time of unassignment (nullable)
        public int Duration { get; set; }       // Duration of the bed assignment
        public bool IsActive { get; set; }     // Indicates whether the assignment is active

        // Navigation properties (optional, if you need to include related data in queries)
        public virtual Member Member { get; set; }      // Navigation property for Member
        public virtual Bed Bed { get; set; }            // Navigation property for Bed
        public virtual Room Room { get; set; }          // Navigation property for Room
        public virtual Branch Branch { get; set; }      // Navigation property for Branch
        public virtual Staff AssignedByStaff { get; set; }  // Navigation property for AssignedBy (Staff)
        public virtual Staff UnassignedByStaff { get; set; } // Navigation property for UnassignedBy (Staff)
    }
}
