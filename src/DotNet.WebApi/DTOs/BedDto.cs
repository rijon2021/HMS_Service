namespace DotNet.WebApi.DTOs
{
    public class BedDto:BaseDto
    {
        public int RoomId { get; set; }
        public string BedNumber { get; set; }
        public bool IsAssigned { get; set; }
    }
}
