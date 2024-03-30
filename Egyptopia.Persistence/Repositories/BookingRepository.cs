using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;

namespace Egyptopia.Persistence.Repositories
{
    public class BookingRepository: BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
