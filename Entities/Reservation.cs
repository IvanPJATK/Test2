namespace WebApplicationTest2.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; } 
        public int GuestId { get; set; }
        public Guest Guest { get; set; } = null!;
        public int RoomId { get; set; } 
        public Room Room { get; set; } = null!;
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string Status { get; set; } = null!;
        public virtual ICollection<Reservation_Service> Reservation_Services { get; set; } = new List<Reservation_Service>();
    }
}
