using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;

namespace Egyptopia.Persistence.Repositories
{
    internal class PlaceRepository : BaseRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}