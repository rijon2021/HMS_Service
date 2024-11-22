using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.Entities.HMS
{
    [Table("Rooms", Schema = "core")]
    public class Room : BaseEntity
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int BranchId { get; set; }// Foreign Key referencing Branch
        public string RoomCategory { get; set; }
        public int Capacity { get; set; }

        // Navigation properties
        public Branch Branch { get; set; }
        public ICollection<Bed> Beds { get; set; }
    }
}
