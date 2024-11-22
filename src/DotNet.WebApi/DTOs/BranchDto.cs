using DotNet.ApplicationCore.Entities.HMS;
using System.ComponentModel.DataAnnotations;
using System;

namespace DotNet.WebApi.DTOs
{
    public class BranchDto
    {
        
        public string BranchCode { get; set; }         // Unique code for each branch
        public string BranchName { get; set; }         // Name of the branch
        public string Location { get; set; }           // Location or address of the branch
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }      // Date when the branch was created
        public DateTime UpdatedDate { get; set; }      // Date when the branch was last updated
                                                       // Foreign Key to reference Hostel entity
        public int HostelId { get; set; }             // Foreign Key referencing Hostel

    }
}
