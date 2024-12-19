using System.ComponentModel.DataAnnotations;

namespace DotNet.WebApi.DTOs
{
    public class PositionDto:BaseDto
    {
        public string PositionName { get; set; }
        public string Description { get; set; }
        public int HierarchyLevel { get; set; }
    }
}
