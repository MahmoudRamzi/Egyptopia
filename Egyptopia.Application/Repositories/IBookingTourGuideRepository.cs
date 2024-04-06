using Egyptopia.Domain.Entities;

namespace Egyptopia.Application.Repositories
{
    public interface IBookingTourGuideRepository : IBaseRepository<BookingTourGuide>
    {
        Task<BookingTourGuide?> GetExistingBooking(DateTime checkInDate, Guid? tourGuideId);
        Task<IEnumerable<BookingTourGuide>> GetBookingsByTourGuideId(Guid tourGuideId);
    }
}