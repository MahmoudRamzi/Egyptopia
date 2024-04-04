using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;

namespace Egyptopia.Persistence.Repositories
{
    public class BookingTourGuideRepository : BaseRepository<BookingTourGuide>, IBookingTourGuideRepository
    {
        public BookingTourGuideRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}