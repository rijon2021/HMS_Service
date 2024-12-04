using DotNet.ApplicationCore.Entities.HMS;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace DotNet.WebApi.DTOs
{
    public class BranchDto: BaseDto
    {
        
        public string BranchCode { get; set; }         // Unique code for each branch
        public string BranchName { get; set; }         // Name of the branch
        public string Location { get; set; }           // Location or address of the branch
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<string> Amenities { get; set; }     // List of available amenities (WiFi, Gym, Library, etc.)
        public int HostelId { get; set; }     // Foreign Key referencing Hostel
        
    }
}
