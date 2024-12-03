using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.Entities.HMS
{
    [Table("RoomCategories", Schema = "core")]
    public class RoomCategory : BaseEntity
    {
        public int Id { get; set; } // Primary Key

        public string Name { get; set; } // Name of the category (e.g., Single, Double, Suite)

        public string Description { get; set; } // Additional details about the room category

        public List<Room> Rooms { get; set; } // Navigation property to associated rooms
    }
}
