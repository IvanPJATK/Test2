namespace WebApplicationTest2.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumb { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal PricePerNig { get; set; }
        public int Floor { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
