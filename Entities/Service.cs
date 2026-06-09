namespace WebApplicationTest2.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int DurationMinut {  get; set; }
        public virtual ICollection<Reservation_Service> Reservation_Services { get; set; } = new List<Reservation_Service>();
    }
}
