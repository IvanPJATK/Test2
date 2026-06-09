namespace WebApplicationTest2.DTOs
{
    public class PostGuestDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public PostGuestReservationDto PostGuestReservation { get; set; } = null!;
    }
}
