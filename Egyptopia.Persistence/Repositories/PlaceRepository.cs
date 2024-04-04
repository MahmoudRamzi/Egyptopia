using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Domain.Enums;
using Egyptopia.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Egyptopia.Persistence.Repositories
{
    internal class PlaceRepository : BaseRepository<Place>, IPlaceRepository
    {
        private DataContext _context;
        public PlaceRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;

        }
        public async Task<List<Place>> GetAllPlacesDetailsByType (PlaceType type)

        {
            return _context.Places.Include(x=>x.Governorate).Where(x=>x.PlaceType == type).ToList();
        }
    } 
}