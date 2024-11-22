using AutoMapper.Execution;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.Entities.HMS
{
    [Table("Branches", Schema = "core")]
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }            // Primary Key
        public string BranchCode { get; set; }         // Unique code for each branch
        public string BranchName { get; set; }         // Name of the branch
        public string Location { get; set; }           // Location or address of the branch
        public string ContactDetails { get; set; }     // Contact details (phone, email, etc.)
        public DateTime CreatedDate { get; set; }      // Date when the branch was created
        public DateTime UpdatedDate { get; set; }      // Date when the branch was last updated
                                                       // Foreign Key to reference Hostel entity
        public int HostelId { get; set; }             // Foreign Key referencing Hostel

        // Navigation properties
        public Hostel Hostel { get; set; }             // Navigation property to related Hostel entity
        
        public ICollection<Room> Rooms { get; set; }   // List of rooms in this branch
        //public ICollection<Member> Members { get; set; } // List of members assigned to this branch
        //public ICollection<Staff> Staff { get; set; }  // List of staff working at this branch
    }
}
