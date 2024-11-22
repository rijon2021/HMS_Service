using AutoMapper.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.Entities.HMS
{
    [Table("Beds", Schema = "core")]
    public  class Bed
    {
        [Key]
        public int BedId { get; set; }
        public int RoomId { get; set; }
        public string BedNumber { get; set; }
        public bool IsAssigned { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Navigation properties
        public Room Room { get; set; }
       // public Member AssignedMember { get; set; }
    }
}
