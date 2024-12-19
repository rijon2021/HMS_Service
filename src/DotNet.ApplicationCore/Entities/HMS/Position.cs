using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.Entities.HMS
{
    [Table("Positions", Schema = "core")]
    public class Position : BaseEntity
    {
        [Key]
        public int PositionId { get; set; }
        [Required]
        public string PositionName { get; set; }
        public string Description { get; set; }
        [Required]
        public int HierarchyLevel { get; set; }       

        // Navigation Property
        public ICollection<Staff> Staffs { get; set; }
    }
}
