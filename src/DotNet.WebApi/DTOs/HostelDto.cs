using System.Collections.Generic;
using System;

namespace DotNet.WebApi.DTOs
{
    public class HostelDto
    {
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
       
        
    }
}
