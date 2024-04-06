using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Egyptopia.Persistence.Repositories
{
    public class BookingTourGuideRepository : BaseRepository<BookingTourGuide>, IBookingTourGuideRepository
    {
        private DataContext _context;
        public BookingTourGuideRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }
        
        // Other repository methods...

        public async Task<BookingTourGuide?> GetExistingBooking(DateTime checkInDate, Guid? tourGuideId)
        {
            return await _context.BookingTourGuides
                .FirstOrDefaultAsync(b => b.CheckInDate.Date == checkInDate.Date && b.TourGuideId == tourGuideId);
        }
    }
}