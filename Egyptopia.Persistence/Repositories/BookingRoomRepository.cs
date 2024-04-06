using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Egyptopia.Persistence.Repositories
{
    public class BookingRoomRepository : BaseRepository<BookingRoom>, IBookingRoomRepository
    {
        private DataContext _context;
        public BookingRoomRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;

        }
        public async Task<List<int>> GetRemainingRooms(Guid hotelId, string roomType, DateTime checkInDate, DateTime checkOutDate)
        {
            var room = await _context.Rooms.Where(room => room.RoomType == roomType).FirstOrDefaultAsync();
            var result = _context.BookingRooms.Include(booking => booking.Room)
                .Where(booking => booking.Room.HotelId == hotelId &&
                    booking.Room.RoomType == roomType &&
                    booking.CheckInDate >= checkInDate &&
                    booking.CheckOutDate <= checkOutDate);
            var remainingRoom = new List<int>();
            for (int i = room.NumberFrom; i <= room.NumberTo; i++)
            {
                var check = result.Where(booking => booking.RoomNumber == i).Any();
                if (!check)
                {
                    remainingRoom.Add(i);
                }

            }
            return remainingRoom;

        }

    }
}
