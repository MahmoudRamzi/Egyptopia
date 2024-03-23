using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;

namespace Egyptopia.Persistence.Repositories
{
    internal class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}