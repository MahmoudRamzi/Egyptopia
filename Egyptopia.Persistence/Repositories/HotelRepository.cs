using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Egyptopia.Persistence.Repositories
{
    internal class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        private readonly DataContext _dataContext;

        public HotelRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Hotel> GetAllWithComments()
        {
            var hotels = _dataContext.Set<Hotel>()
                .Include(h => h.HotelComments)
                .ToList();
            return hotels;
        }

        public Hotel GetWithComments(Guid id)
        {
            var hotel = _dataContext.Set<Hotel>()
                .Include(h => h.HotelComments)
                .SingleOrDefault(d => d.Id == id);
            return hotel;
        }
    }
}