namespace DotNet.WebApi.DTOs
{
    public class RoomDto: BaseDto
    {
        public string RoomNumber { get; set; }
        public int BranchId { get; set; }// Foreign Key referencing Branch
        public int RoomCategoryId { get; set; }
        public int Capacity { get; set; }
    }
}
