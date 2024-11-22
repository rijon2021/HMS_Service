using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNet.ApplicationCore.Entities.HMS
{
     [Table("Hostels", Schema = "core")]
    public class Hostel
    {
        [Key]
        public int HostelId { get; set; }             // Primary Key
        public string HostelName { get; set; }          // Name of the hostel
        public string Address { get; set; }             // Address of the main hostel office
        public string ContactNumber { get; set; }       // Contact phone number
        public string Email { get; set; }               // Email address for inquiries
        public string Website { get; set; }             // Website URL (if any)
        public int TotalBranches { get; set; }          // Number of branches under the hostel
        public DateTime EstablishedDate { get; set; }   // Date of establishment
        public string Description { get; set; }         // Short description or overview of the hostel
        public List<string> Amenities { get; set; }     // List of available amenities (WiFi, Gym, Library, etc.)
        public string HostelManager { get; set; }       // Name of the overall manager responsible for the hostel
        public DateTime CreatedDate { get; set; }       // Date when the record was created
        public DateTime UpdatedDate { get; set; }       // Date when the record was last updated

        // Navigation properties
        public ICollection<Branch> Branches { get; set; }  // List of branches under the hostel
    }
}
