namespace DotNet.WebApi.DTOs
{
    public class RoomCategoryDto: BaseDto
    {
        public string Name { get; set; } // Name of the category (e.g., Single, Double, Suite)
        public string Description { get; set; } // Additional details about the room category
       
    }
}
