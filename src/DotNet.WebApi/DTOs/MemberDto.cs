using DotNet.ApplicationCore.Entities.HMS;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DotNet.WebApi.DTOs
{
    public class MemberDto:BaseDto
    {
       
        public string FullName { get; set; }
        public string Gender { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public string IdentityNumber { get; set; }  //NID/BID/Passport No
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int BranchId { get; set; }

        public int? RoomId { get; set; }
        public int? BedId { get; set; }
    }
}
