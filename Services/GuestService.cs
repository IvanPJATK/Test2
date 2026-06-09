using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using WebApplicationTest2.Data;
using WebApplicationTest2.DTOs;
using WebApplicationTest2.Entities;

namespace WebApplicationTest2.Services
{
    public class GuestService : IGuestService
    {
        private readonly ApplicationDbContext _context;
        public GuestService(ApplicationDbContext context) { _context = context; }

        public async Task<(bool IsSuccess, string Message)> AddNewGuest(PostGuestDto guest)
        {
            if (guest.Reservation.CheckInDate < DateTime.Now)
            {
                return (false, "The reservation cannot be in the past");
            }
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var room_check = await _context.Rooms.AnyAsync(r => r.RoomId == guest.Reservation.RoomId);
                if (!room_check)
                {
                    return (false, $"Selected toom with id {guest.Reservation.RoomId} does not exist");
                }
                var new_guest = new Guest
                {
                    FirstName = guest.FirstName,
                    LastName = guest.LastName,
                    Email = guest.Email,
                    Phone = guest.Phone,
                };
                await _context.Guests.AddAsync(new_guest);
                var new_reservation = new Reservation
                {
                    GuestId = new_guest.GuestId,
                    RoomId = guest.Reservation.RoomId,
                    CheckInDate = guest.Reservation.CheckInDate,
                    Status = "Reserved"
                };
                await _context.Reservations.AddAsync(new_reservation);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return (true, "The guest and reservation added successfully");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
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
