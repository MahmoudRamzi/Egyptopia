using Egyptopia.Application.Repositories;
using Egyptopia.Domain.Entities;
using Egyptopia.Persistence.Context;

namespace Egyptopia.Persistence.Repositories
{
    internal class TourGuideServiceRepository : BaseRepository<TourGuideService>, ITourGuideServiceRepository
    {
        public TourGuideServiceRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}