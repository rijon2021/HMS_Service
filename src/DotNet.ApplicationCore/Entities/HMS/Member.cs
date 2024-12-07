using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.Entities.HMS
{
    [Table("Members", Schema = "core")]
    public class Member:BaseEntity
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Gender { get; set; } // Consider using an Enum for Gender

        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string IdentityNumber  { get; set; }  //NID/BID/Passport No

        [Required]
        public string Mobile{ get; set; }        
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        public int? RoomId { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        public int? BedId { get; set; }

        [ForeignKey("BedId")]
        public virtual Bed Bed { get; set; }

    }
}
