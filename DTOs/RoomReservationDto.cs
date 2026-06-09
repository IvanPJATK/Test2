namespace WebApplicationTest2.DTOs
{
    public class RoomReservationDto
    {
        public int ReservationId { get; set; }
        public ReservationGuestDto Guest { get; set; } = null!;
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string Status { get; set; } = null!;
        public List<ReservationServiceDto> ReservationServices { get; set; } = new List<ReservationServiceDto>();
    }
}
