namespace WebApplicationTest2.DTOs
{
    public class ReservationServiceDto
    {
        public int Quantity { get; set; }
        public DateTime ServiceDate { get; set; }
        public ServiceDto Service { get; set; } = null!;
    }
}
