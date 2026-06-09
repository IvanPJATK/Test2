namespace WebApplicationTest2.Entities
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; } =  new List<Reservation>();
    }
}
