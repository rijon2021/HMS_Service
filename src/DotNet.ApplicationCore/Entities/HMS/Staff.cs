using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.Entities.HMS
{
    [Table("Staffs", Schema = "core")]
    public class Staff :BaseEntity
    {
        [Key]
        public int StaffId { get; set; }
        public string? StaffIdNo { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Gender { get; set; } // Consider using an Enum for Gender
        
        [Required]
        public DateTime JoiningDate { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string IdentityNumber { get; set; }  //NID/BID/Passport No

        [Required]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        [Required]
        [ForeignKey("PositionId")]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        [Required]
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }
    }
}
