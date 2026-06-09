using WebApplicationTest2.DTOs;

namespace WebApplicationTest2.Services
{
    public interface IGuestService
    {
        Task<GetRoomDto?> GetRoomDetailsAsync(int id);
        Task<(bool IsSuccess, string Message)> AddNewGuest(PostGuestDto guest);
    }
}
