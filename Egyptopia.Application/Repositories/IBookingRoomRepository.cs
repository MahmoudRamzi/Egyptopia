using Egyptopia.Domain.Entities;

namespace Egyptopia.Application.Repositories
{
    public interface IBookingRoomRepository : IBaseRepository<BookingRoom>
    {
        Task<List<int>> GetRemainingRooms(Guid hotelId, string roomType, DateTime checkInDate, DateTime checkOutDate);
    }
}