namespace WebApplicationTest2.Entities
{
    public class Reservation_Service
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
