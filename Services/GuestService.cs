using Microsoft.EntityFrameworkCore;
using WebApplicationTest2.Data;
using WebApplicationTest2.DTOs;

namespace WebApplicationTest2.Services
{
    public class GuestService : IGuestService
    {
        private readonly ApplicationDbContext _context;
        public GuestService(ApplicationDbContext context) { _context = context; }

        public async Task<(bool IsSuccess, string Message)> AddNewGuest(PostGuestDto guest)
        {
            
        }

        public async Task<GetRoomDto?> GetRoomDetailsAsync(int id)
        {
            return await _context.Rooms.Select(r => new GetRoomDto
            {
                RoomId = r.RoomId,
                RoomNumber = r.RoomNumb,
                Type = r.Type,
                PricePerNight = r.PricePerNig,
                Floor = r.Floor,
                Reservations = _context.Reservations.Where(rs => rs.RoomId == id).Select(rs => new RoomReservationDto
                {
                    ReservationId = rs.ReservationId,
                    Guest = new ReservationGuestDto
                    {
                        FirstName = rs.Guest.FirstName,
                        LastName = rs.Guest.LastName,
                        Email = rs.Guest.Email,
                        Phone = rs.Guest.Phone,
                    },
                    CheckInDate = rs.CheckInDate,
                    CheckOutDate = rs.CheckOutDate,
                    Status = rs.Status,
                    ReservationServices = _context.Reservation_Services.Where(rss => rss.ReservationId == id).Select(rss => new ReservationServiceDto
                    {
                        Quantity = rss.Quantity,
                        ServiceDate = rss.ServiceDate,
                        Service = new ServiceDto
                        {
                            ServiceId = rss.Service.ServiceId,
                            Name = rss.Service.Name,
                            Description = rss.Service.Description,
                            Price = rss.Service.Price,
                            DurationMinutes = rss.Service.DurationMinut
                        }
                    }).ToList()
                }).ToList(),
            }).FirstOrDefaultAsync(r => r.RoomId == id);
        }
    }
}
