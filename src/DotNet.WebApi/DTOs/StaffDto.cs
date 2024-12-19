using System;

namespace DotNet.WebApi.DTOs
{
    public class StaffDto:BaseDto
    {
        public string FullName { get; set; }
        public string? StaffIdNo { get; set; }
        public string Gender { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityNumber { get; set; }  //NID/BID/Passport No
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PositionId { get; set; }
        public int BranchId { get; set; }
    }
}
