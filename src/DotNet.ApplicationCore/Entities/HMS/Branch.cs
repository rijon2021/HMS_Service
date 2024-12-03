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
    public class Branch:BaseEntity
    {
        [Key]
        public int BranchId { get; set; }            // Primary Key
        public string BranchCode { get; set; }         // Unique code for each branch
        public string BranchName { get; set; }         // Name of the branch
        public string Location { get; set; }           // Location or address of the branch
        public string ContactNumber { get; set; }     // Phone/Mobile
        public string Email { get; set; }
        public List<string> Amenities { get; set; }     // List of available amenities (WiFi, Gym, Library, etc.)
        public int HostelId { get; set; }             // Foreign Key referencing Hostel

        // Navigation properties
        public Hostel Hostel { get; set; }             // Navigation property to related Hostel entity
        
        public ICollection<Room> Rooms { get; set; }   // List of rooms in this branch
        //public ICollection<Member> Members { get; set; } // List of members assigned to this branch
        //public ICollection<Staff> Staff { get; set; }  // List of staff working at this branch
    }
}
