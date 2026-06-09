namespace WebApplicationTest2.DTOs
{
    public class GetRoomDto
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal PricePerNight { get; set; }
        public int Floor {  get; set; }
        public List<RoomReservationDto> Reservations { get; set; } = new List<RoomReservationDto>();
    }
}
